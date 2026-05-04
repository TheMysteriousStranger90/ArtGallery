using ArtGallery.WebAPI.Errors;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace ArtGallery.WebAPI.Extensions;

public static class ErrorNotificationExtensions
{
    public static LoggerConfiguration AlertOnError(
        this LoggerSinkConfiguration sinkConfiguration,
        string webhookUrl = null,
        LogEventLevel restrictedToMinimumLevel = LogEventLevel.Error)
    {
        return sinkConfiguration.Sink(new ErrorAlertSink(webhookUrl), restrictedToMinimumLevel);
    }

    public static IServiceCollection AddErrorNotifier(this IServiceCollection services)
    {
        services.AddSingleton<IErrorNotifier, ErrorNotifier>();
        return services;
    }
}