using CadCli.Domain.Entities;
using CadCli.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CadCli.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _cliRep;
        public ClientesController(IClienteRepository cliRep)
        {
            _cliRep = cliRep;
        }

        public async Task<IActionResult> Get()
        {
            //wildermuth.com/2015/09/27/A_Look_at_ASP_NET_5_Part_5_-_The_API

            var dados = 
                await _cliRep.Get()
                //false => retorna para qualquer thread pool não necessariamente a original
                .ConfigureAwait(false);

            //Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //Response.StatusCode = (int)HttpStatusCode.OK;

            return Json(dados);
        }

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente =
                await _cliRep.Get(id).ConfigureAwait(false);

            if (cliente == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            return Json(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Cliente cli) {

            Cliente cliente = null;
            if (cli == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                cliente = await _cliRep.Add(cli);
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            return Json(cliente);
        }

    }
}
