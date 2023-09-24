namespace HttpRequest.API.Handlers;

public interface IHttpRequestContext
{
    string Name { get; }
    bool IsAuthenticated();
    HttpContext GetHttpContext();
}