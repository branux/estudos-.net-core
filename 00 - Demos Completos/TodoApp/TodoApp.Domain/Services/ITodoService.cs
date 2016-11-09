using System.Collections.Generic;
using TodoApp.Domain.Dtos;

namespace TodoApp.Domain.Services
{
    public interface ITodoService
    {
        TodoDTO Create(TodoDTO todo);
        TodoDTO Update(TodoDTO todo);
        bool Delete(int id);
        IEnumerable<TodoDTO> GetAll();
        TodoDTO GetById(int id);
    }
}
