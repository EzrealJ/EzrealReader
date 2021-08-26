using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EzrealReader
{
    internal class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            this.Configuration = configuration;
            this.HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }

        public IHostEnvironment HostEnvironment { get; }

        internal IServiceCollection ConfigureServices(IServiceCollection services)
        {
            Debug.WriteLine($"Invoke {nameof(ConfigureServices)}");
            return services;
        }

        internal void ConfigureApplication(IServiceProvider services)
        {
            Debug.WriteLine($"Invoke {nameof(ConfigureApplication)}");
        }
    }
}
