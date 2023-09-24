using Polly;
using Polly.Extensions.Http;

namespace HttpRequest.API.Handlers;

public static class PollyPolicy
{

    public static IAsyncPolicy<HttpResponseMessage> WaitAndRetryHttpResponse()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<Exception>()
            .WaitAndRetryAsync(new[]
            {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
            }, (message, timespan, retryCount, context) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Out.WriteLine($"URL: {message.Result?.RequestMessage?.Method} {message.Result?.RequestMessage?.RequestUri}");
                Console.Out.WriteLine($"Conteúdo: {message.Result?.Content?.ReadAsStringAsync()?.Result}");
                Console.Out.WriteLine($"Motivo: {message.Result?.ReasonPhrase}");
                Console.Out.WriteLine($"Erro: {message.Exception?.Message}");
                Console.Out.WriteLine($"Tentanto pela {retryCount} vez!");
                Console.ForegroundColor = ConsoleColor.White;
            });
    }

    public static IAsyncPolicy WaitAndRetry()
    {
        return Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(new[]
            {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
            }, (Exception, timespan, retryCount, context) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Out.WriteLine($"Motivo: {Exception?.Message}");
                Console.Out.WriteLine($"Tentanto pela {retryCount} vez!");
                Console.ForegroundColor = ConsoleColor.White;
            });
    }

}
