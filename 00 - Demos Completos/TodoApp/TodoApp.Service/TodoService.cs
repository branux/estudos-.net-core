using System.Collections.Generic;
using TodoApp.Domain.Dtos;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;
using TodoApp.Domain.Services;
using TodoApp.Service.Helpers;

namespace TodoApp.Service
{
    internal class TodoService : BaseService, ITodoService
    {
        private readonly ITodoRepository _todoRep;
        public TodoService(ITodoRepository todoRep)
        {
            this._todoRep = todoRep;
        }

        public TodoDTO Create(TodoDTO todo)
        {
            var result = _todoRep.Create(todo.MapTo<Todo>());
            return result.MapTo<TodoDTO>();
        }

        public bool Delete(int id)
        {
            return _todoRep.Delete(id);
        }

        public IEnumerable<TodoDTO> GetAll()
        {
            return _todoRep.GetAll().EnumerableTo<TodoDTO>();
        }

        public TodoDTO GetById(int id)
        {
            return _todoRep.GetById(id).MapTo<TodoDTO>();
        }

        public TodoDTO Update(TodoDTO todo)
        {
            var result = _todoRep.Update(todo.MapTo<Todo>());
            return result.MapTo<TodoDTO>();
        }
    }
}
