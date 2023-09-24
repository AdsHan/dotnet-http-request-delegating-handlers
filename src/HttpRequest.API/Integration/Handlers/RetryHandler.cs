using HttpRequest.API.Handlers;
using Polly;

namespace HttpRequest.API.Integration.Handlers;

public class RetryHandler : DelegatingHandler
{

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var result = await PollyPolicy.WaitAndRetryHttpResponse().
            ExecuteAndCaptureAsync(() => base.SendAsync(request, cancellationToken));

        if (result.Outcome == OutcomeType.Failure)
        {
            throw new HttpRequestException("Erro Request", result.FinalException);
        }

        return result.Result;
    }
}