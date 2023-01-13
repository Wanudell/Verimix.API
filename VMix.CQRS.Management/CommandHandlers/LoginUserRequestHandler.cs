namespace VMix.CQRS.Management.CommandHandlers;

internal class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginResultDto>
{
	private readonly IUnitOfWork unitOfWork;
	private readonly IConfiguration config;

	public LoginUserRequestHandler(IUnitOfWork unitOfWork, IConfiguration config)
	{
		this.unitOfWork = unitOfWork;
		this.config = config;
	}

	public async Task<LoginResultDto> Handle(LoginUserRequest request, CancellationToken cancellationToken)
	{
		var key = config.GetValue<string>("Jwt:Key");
		var expires = config.GetValue<int>("Jwt:ExpiresInMinutes");
		var repository = unitOfWork.GetRepository<User>();
		var entity = await repository.Get(x => x.UserName == request.Data.UserName, cancellationToken);
		if (entity == null)
		{
			return null;
		}
		var password = (request.Data.Password + entity.PasswordHash).CreateHash();
		if (entity.Password != password)
		{
			return null;
		}

		var claims = new Dictionary<string, object>();
		claims.Add(ClaimTypes.NameIdentifier, entity.Id);
		claims.Add(ClaimTypes.GivenName, entity.UserName);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Expires = DateTime.Now.AddMinutes(expires),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature),
			Claims = claims,
			IssuedAt = DateTime.Now,
			NotBefore = DateTime.Now,
		};
		var handler = new JwtSecurityTokenHandler();
		var token = handler.CreateToken(tokenDescriptor);
		var jwtToken = handler.WriteToken(token);
		entity.RefreshToken = Guid.NewGuid();
		repository.Update(entity);
		unitOfWork.SaveChanges(cancellationToken);
		return new LoginResultDto { Token = jwtToken, DisplayName = entity.FullName , RefreshToken = entity.RefreshToken.ToString(), Id = entity.Id };
	}
}

//refreshtoken - token - expiresinminutes db'ye kaydedilmeli