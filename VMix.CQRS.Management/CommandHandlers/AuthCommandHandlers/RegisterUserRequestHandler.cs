namespace VMix.CQRS.Management.CommandHandlers.AuthCommandHandlers;

internal class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IConfiguration config;

    public RegisterUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.config = config;
    }

    public async Task<bool> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var key = config.GetValue<string>("Jwt:Key");
        var expires = config.GetValue<int>("Jwt:ExpiresInMinutes");
        var repository = unitOfWork.GetRepository<AuthUser>();
        var existingUser = await repository.Get(x => x.userName == request.Data.UserName || x.email == request.Data.Email, cancellationToken);
        if (existingUser != null)
        {
            return false;
        }

        var claims = new Dictionary<string, object>();
        claims.Add(ClaimTypes.Email, request.Data.Email);
        claims.Add(ClaimTypes.GivenName, request.Data.FullName);

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

        var entity = mapper.Map<AuthUser>(request.Data);
        entity.refreshTokenEndDate = DateTime.Now.AddMinutes(expires);
        entity.token = jwtToken;
        entity.refreshToken = Guid.NewGuid();
        entity.passwordHash = Guid.NewGuid().ToString();
        entity.password = (request.Data.Password + entity.passwordHash).CreateHash();
        repository.Insert(entity);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}
