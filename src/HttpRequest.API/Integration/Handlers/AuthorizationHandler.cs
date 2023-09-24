using HttpRequest.API.Handlers;

namespace HttpRequest.API.Integration.Handlers;

public class AuthorizationHandler : DelegatingHandler
{
    private readonly IHttpRequestContext _httpRequestContext;

    public AuthorizationHandler(IHttpRequestContext httpRequestContext)
    {
        _httpRequestContext = httpRequestContext;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var authorizationHeader = _httpRequestContext.GetHttpContext().Request.Headers["Authorization"];

        if (!string.IsNullOrEmpty(authorizationHeader))
        {
            request.Headers.Add("Authorization", new List<string>() { authorizationHeader });
        }

        return await base.SendAsync(request, cancellationToken);
    }
}