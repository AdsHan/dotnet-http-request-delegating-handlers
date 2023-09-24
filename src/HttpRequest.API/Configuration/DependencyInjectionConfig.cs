using HttpRequest.API.Handlers;
using HttpRequest.API.Integration.Handlers;
using HttpRequest.API.Integration.Services;

namespace HttpRequest.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IHttpRequestContext, HttpRequestContext>();

        services.AddTransient<AuthorizationHandler>();
        services.AddTransient<LoggingHandler>();
        services.AddTransient<RetryHandler>();

        services.AddHttpClient<IUserService, UserService>()
            .AddHttpMessageHandler<AuthorizationHandler>()
            .AddHttpMessageHandler<LoggingHandler>()
            .AddHttpMessageHandler<RetryHandler>();

        //.AddPolicyHandler(PollyPolicy.WaitAndRetryHttpResponse());

        return services;
    }
}
