using JSLibrary.TPL;
using NLog.Web;

namespace Passive.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
#if DEV || DEBUG
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
#else
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
#endif
            ParallelTask.SetMultiplicator(1);
        }

        private static IHostBuilder CreateDefaultHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args).ConfigureWebHostDefaults(webbuilder =>
            {
                webbuilder.UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddSimpleConsole();
                })
                .UseNLog();
            });
    }
}
