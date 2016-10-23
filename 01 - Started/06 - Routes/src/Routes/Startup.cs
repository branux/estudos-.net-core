using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;

namespace Routes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = ctx => ctx.Response.WriteAsync("Algo errado")
                });
            }

            //app.UseMvcWithDefaultRoute();
            
            //app.UseMvc(config =>
            //    config.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"),
            //);

            app.UseMvc(Infra.RouteConfig.RegisterRoutes);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Página não encontrada!");
            });
        }
    }
}
