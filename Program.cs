using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using dotnet_6_crud_api.Helpers;

using System;
using System.Net.NetworkInformation;

namespace dotnet_6_crud_api
{
    public class Program
    {
        public static string MyDefaultURL = "http://localhost:4000"; //"http://192.168.0.137:4000";
        // public static string MyDefaultURL = string.Format("http://{0}:4000", FileHandler.GetLocalIPAddress(NetworkInterfaceType.Ethernet));
        public const string RefinedURL = "https://session.poolreno.com/statics";        
        // public const string MyDefaultURL = "http://178.128.94.184:4000";
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // change to localhost on testing
                    webBuilder.UseStartup<Startup>()
                        .UseKestrel(options =>
                        {
                            options.Limits.MaxRequestBodySize = long.MaxValue;
                        })
                        .UseUrls(MyDefaultURL);
                });
                
    }
}