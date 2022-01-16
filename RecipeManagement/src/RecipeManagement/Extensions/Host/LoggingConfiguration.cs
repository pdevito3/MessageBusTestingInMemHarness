namespace RecipeManagement.Extensions.Host;

using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

public static class LoggingConfiguration
{
    public static void AddLoggingConfiguration(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var env = services.GetService<IWebHostEnvironment>();
        
        var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
            .Enrich.WithProperty("ApplicationName", env.ApplicationName)
            .Enrich.WithExceptionDetails()
            .Enrich.WithProcessId()
            .Enrich.WithThreadId()
            .Enrich.WithMachineName()
            .WriteTo.Console();

        if (env.IsProduction())
            logger.MinimumLevel.Error();
        
        if (env.IsDevelopment())
            logger.MinimumLevel.Debug();

        Log.Logger = logger.CreateLogger();
    }
}