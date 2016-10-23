using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Routes.Infra
{
    public class RouteConfig
    {

        public static void RegisterRoutes(IRouteBuilder routes)
        {
            routes.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");

            routes.MapRoute("Teste",
                "teste/{controller=Teste}/{action=Index}/{id?}");
        }

    }
}
