using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace Confitec.Technical.Test.Infra.Crosscutting.Logger
{
    public static class LogConfiguration
    {
        public static void ConfigureLog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Async(wt => wt.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"))
                .CreateLogger();
        }
    }
}
