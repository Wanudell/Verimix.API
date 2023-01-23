namespace VMix.CQRS.Management.CommandHandlers.AuthCommandHandlers;

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
        var repository = unitOfWork.GetRepository<AuthUser>();
        var entity = await repository.Get(x => x.id == request.Data.Id, cancellationToken);
        if (entity == null)
        {
            return null;
        }
        if (entity.refreshToken != request.Data.RefreshToken || entity.token == request.Data.Token)
        {
            return null;
        }
        var claims = new Dictionary<string, object>();
        claims.Add(ClaimTypes.NameIdentifier, entity.id);
        claims.Add(ClaimTypes.GivenName, entity.userName);

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
            Id = entity.id
        };
        entity.refreshToken = Guid.Parse(result.RefreshToken);
        repository.Update(entity);
        unitOfWork.SaveChanges(cancellationToken);
        return new RefreshTokenResultDto { Token = jwtToken, RefreshToken = entity.refreshToken.ToString(), ExpiresInMinutes = result.ExpiresInMinutes, Id = entity.id };
    }
}
