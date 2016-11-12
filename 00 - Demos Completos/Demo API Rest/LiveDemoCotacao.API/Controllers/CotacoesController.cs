using LiveDemoCotacao.API.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LiveDemoCotacao.API.Controllers
{
    [Route("api/[controller]")]
    public class CotacoesController : Controller
    {
        private readonly CotacoesContext _context;

        public CotacoesController(CotacoesContext context)
        {
            this._context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            //[FromServices]CotacoesContext context, //IoC no Método
            string id)
        {
            dynamic dados;
            try
            {
                dados = await
                    Task.Run(() =>
                        _context.Cotacoes.FirstOrDefault(c => c.Sigla == id)
                    );

                if (dados == null)
                    Response.StatusCode = (int)HttpStatusCode.NotFound;

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                dados = $"Erro no acesso à dados {Environment.NewLine + ex.Message}";
            }

            return Json(dados);
        }


        [HttpGet()]
        public IActionResult Get()
        {
            dynamic dados;
            try
            {
                dados = _context.Cotacoes.ToList();
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                dados = $"Erro no acesso à dados {Environment.NewLine + ex.Message}";
            }

            return Json(dados);
        }


    }
}
