namespace VMix.Net.API.Helpers;

public static class SessionExtensions
{
    /// <summary>
    /// aktif kullanıcının bilgisini alır.
    /// </summary>
    /// <returns></returns>
    public static Task<GetUserByTokenDto> GetCurrentUser(this IUserService service, HttpRequest req, CancellationToken cancellationToken)
    {
        var token = req.Headers["Authorization"].ToString().Split(' ')[1];
        Task<GetUserByTokenDto> result = service.GetUserByToken(token, cancellationToken);
        return result;
    }

}
