using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;

namespace vindorel_Online
{
    public interface IFoo {  }
    public  class Foo : IFoo { }
    public class Startup
    {
        IConfiguration config;
            public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("config.json");
            config = builder.Build();
             

        }
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddTransient<IFoo,Foo>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
