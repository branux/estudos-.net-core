using CadCli.Domain.Repositories;
using System.Collections.Generic;
using CadCli.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CadCli.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CadCliContext _ctx;
        public ClienteRepository()
        {
            _ctx = new CadCliContext();
        }
        public async Task<Cliente> Add(Cliente cliente)
        {
            _ctx.Clientes.Add(cliente);
            await _ctx.SaveChangesAsync();
            return cliente;
        }

        //public Task<IEnumerable<Cliente>> Get()
        //{
        //    var tDados = Task.Run(() =>
        //    {
        //        return _ctx.Clientes.AsEnumerable();
        //    });

        //    return tDados;
        //}

        //public async Task<IEnumerable<Cliente>> Get()
        //{
        //    var dados = _ctx.Clientes.ToListAsync();
        //    var log = Task.Run(() => Task.Delay(2000));

        //    //Executar todas as tasks
        //    await Task.WhenAll(dados, log);

        //    return dados.Result;
        //}


        public async Task<IEnumerable<Cliente>> Get()
        {
            var dados = await _ctx.Clientes.Include(d=>d.Pedidos).ToListAsync();
            //dados.Select(d => d.Pedidos);

            return dados;
        }

        public async Task<Cliente> Get(int id)
        {
            return
                await _ctx.Clientes
                    .FirstOrDefaultAsync(cli => cli.Id == id);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
