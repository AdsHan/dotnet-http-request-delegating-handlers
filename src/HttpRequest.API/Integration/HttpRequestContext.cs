namespace HttpRequest.API.Handlers;

public class HttpRequestContext : IHttpRequestContext
{
    private readonly IHttpContextAccessor _accessor;

    public HttpRequestContext(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public string Name => _accessor.HttpContext.User.Identity.Name;

    public bool IsAuthenticated()
    {
        return _accessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public HttpContext GetHttpContext()
    {
        return _accessor.HttpContext;
    }

}