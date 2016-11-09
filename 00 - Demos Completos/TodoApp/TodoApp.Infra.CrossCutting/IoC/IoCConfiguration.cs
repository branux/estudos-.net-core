using Microsoft.Extensions.DependencyInjection;
using TodoApp.Data.Repositories;
using TodoApp.Domain.Repositories;
using TodoApp.Domain.Services;
using TodoApp.Service;

namespace TodoApp.Infra.CrossCutting.IoC
{
    public class IoCConfiguration
    {

        public static void Configure(IServiceCollection services) {

            services.AddScoped(typeof(ITodoRepository), typeof(TodoRepository));
            services.AddScoped(typeof(ITodoService), typeof(TodoService));
        }

    }


}
