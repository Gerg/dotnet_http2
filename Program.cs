using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace net_http2_sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit +=
                 (sender, eventArgs) => {
                     Console.WriteLine("Goodbye, cruel world!");
                 };
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((options) =>
                    {
                        options.ConfigureEndpointDefaults(lo => lo.Protocols = HttpProtocols.Http2);
                        options.AllowAlternateSchemes = true;
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
