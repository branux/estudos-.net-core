using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TodoApp.Infra.CrossCutting")]
namespace TodoApp.Data.Repositories
{
    internal abstract class BaseRepository
    {
        private const string CONNECTIONSTRING_KEY = "ConnectionStrings:ConnTodo";

        protected readonly IDbConnection connection;

        public BaseRepository(IConfigurationRoot config)
        {
            var conn = config.GetSection(CONNECTIONSTRING_KEY).Value;

            if (string.IsNullOrWhiteSpace(conn))
            {
                throw new ArgumentException("Connection string not found");
            }

            connection = new SqlConnection(conn);
        }
    }
}
