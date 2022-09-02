using Confitec.Technical.Test.Infra.Crosscutting.Logger;
using Serilog;

namespace Confitec.Technical.Test.Api.Extensions
{
    public static class LogExtensiong
    {
        public static void ConfigureLog(this WebApplicationBuilder builder)
        {
            LogConfiguration.ConfigureLog();
            builder.Host.UseSerilog(Log.Logger);
        }
    }
}
