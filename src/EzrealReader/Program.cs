using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EzrealReader
{
    public static class Program
    {
		private static Startup _startup;
		public static void Main(string[] args)
		{
			_startup = new Startup();
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseWinForm<MainForm>()
				.UseWinFormHostLifetime()
				.ConfigureServices(services => _startup.ConfigureServices(services));
	}
}
