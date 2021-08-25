using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EzrealReader
{
    internal class Startup
    {
        public Startup()
        {
        }

        public IConfiguration? Configuration { get; }

        internal IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services;
        }
    }
}
