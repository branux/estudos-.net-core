using System.Collections.Generic;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories
{
    public interface ITodoRepository
    {
        Todo Create(Todo todo);
        Todo Update(Todo todo);
        bool Delete(int id);
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);

    }
}
