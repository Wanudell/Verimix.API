namespace VMix.CQRS.Management.CommandHandlers;

internal class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenResultDto>
{
	private readonly IUnitOfWork unitOfWork;
	private readonly IConfiguration config;

	public RefreshTokenRequestHandler(IUnitOfWork unitOfWork, IConfiguration config)
	{
		this.unitOfWork = unitOfWork;
		this.config = config;
	}

	public async Task<RefreshTokenResultDto> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
	{
		var key = config.GetValue<string>("Jwt:Key");
		var expires = config.GetValue<int>("Jwt:ExpiresInMinutes");
		var repository = unitOfWork.GetRepository<User>();
		var entity = await repository.Get(x => x.Id == request.Data.Id, cancellationToken);
		if (entity == null)
		{
			return null;
		}
		if(entity.RefreshToken != request.Data.RefreshToken || entity.Token == request.Data.Token)
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
			NotBefore = DateTime.Now
		};

		var handler = new JwtSecurityTokenHandler();
		var token = handler.CreateToken(tokenDescriptor);
		var jwtToken = handler.WriteToken(token);

		var result = new RefreshTokenResultDto 
		{ 
			RefreshToken = Guid.NewGuid().ToString(),
			ExpiresInMinutes = DateTime.Now.AddMinutes(expires),
			Id = entity.Id
		};
		entity.RefreshToken = Guid.Parse(result.RefreshToken);
		repository.Update(entity);
		unitOfWork.SaveChanges(cancellationToken);
		return new RefreshTokenResultDto { RefreshToken = entity.RefreshToken.ToString(), ExpiresInMinutes = result.ExpiresInMinutes, Id = entity.Id};
	}
}
