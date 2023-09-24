namespace HttpRequest.API.Integration.Handlers;

public class LoggingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHandler> _logger;

    public LoggingHandler(ILogger<LoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Before Request");

            var result = await base.SendAsync(request, cancellationToken);

            _logger.LogInformation("Before Request");

            return result;
        }
        catch (Exception)
        {
            _logger.LogError("Before Request");

            throw;
        }
    }
}