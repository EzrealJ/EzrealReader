using Microsoft.Extensions.Hosting;

namespace EzrealReader
{
    public static class Program
    {
        private static Startup? _startup;
        public static void Main(string[] args)
        {
            IHost winFormHost = CreateHostBuilder(args).Build();
            _startup?.ConfigureApplication(winFormHost.Services);
            winFormHost.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWinForm<MainForm>()
                .UseWinFormHostLifetime()            
            .ConfigureAppConfiguration((hostBuilder, configurationBuilder) =>
            {
                _startup = new Startup(configurationBuilder.Build(), hostBuilder.HostingEnvironment);
            })
            .ConfigureServices(services => _startup?.ConfigureServices(services));
    }
}
