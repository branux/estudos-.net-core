using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Services;
using TodoApp.Domain.Dtos;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoServ;
        public TodoController(ITodoService todoServ)
        {
            this._todoServ = todoServ;
        }
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<TodoDTO> Get()
        {
            return _todoServ.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TodoDTO Get(int id)
        {
            return _todoServ.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public TodoDTO Post([FromBody]TodoDTO todo)
        {
            return _todoServ.Create(todo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public TodoDTO Put(int id, [FromBody]TodoDTO todo)
        {
            todo.Id = id;
            return _todoServ.Update(todo);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _todoServ.Delete(id);
        }
    }
}
