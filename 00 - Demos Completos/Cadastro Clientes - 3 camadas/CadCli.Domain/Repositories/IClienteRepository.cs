using CadCli.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadCli.Domain.Repositories
{
    public interface IClienteRepository : IDisposable
    {
        Task<IEnumerable<Cliente>> Get();
        Task<Cliente> Get(int id);
        Task<Cliente> Add(Cliente cliente);
    }
}
