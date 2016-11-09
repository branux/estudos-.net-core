using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Data.Repositories
{
    internal class TodoRepository : BaseRepository, ITodoRepository
    {
        public TodoRepository(IConfigurationRoot config)
            : base(config)
        { }

        public Todo Create(Todo todo)
        {
            var sql =
                "INSERT INTO Todo (Text, IsCompleted) VALUES(@Text, @IsCompleted); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = connection.Query<int>(sql, todo).Single();
            todo.Id = id;
            return todo;
        }

        public bool Delete(int id)
        {
            var affectRows = connection.Execute("DELETE FROM Todo WHERE ID=@Id", new { id });
            return affectRows > 0;
        }

        public IEnumerable<Todo> GetAll()
        {
            return connection.Query<Todo>("SELECT * FROM Todo");
        }

        public Todo GetById(int id)
        {
            return connection.QueryFirstOrDefault<Todo>("SELECT * FROM TODO WHERE Id = @Id", new { id });
        }

        public Todo Update(Todo todo)
        {
            var sql =
                "UPDATE Todo " +
                "SET Text = @Text, " +
                "    IsCompleted  = @IsCompleted " +
                "WHERE Id = @Id";
            var affectRows = connection.Execute(sql, todo);
            return todo;
        }
    }
}
