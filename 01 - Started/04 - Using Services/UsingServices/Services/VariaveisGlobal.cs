using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace UsingServices.Services
{
    public class VariaveisGlobal : IVariaveisGlobal
    {
        private IConfiguration _config { get; set; }
        public VariaveisGlobal(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables();
            _config = builder.Build();
        }

        public string ObterStringConexao()
        {
            return _config["ConnectionStrings:DefaultConnection"];
        }

        public string ObterVariavelTeste()
        {
            return _config["VariavelTeste"];
        }
    }
}
