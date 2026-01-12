using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Persistence
{
    public class EmployeeContext
    {
        private readonly string _connectionString;
        public EmployeeContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<int> ExecuteStoredProcedureAsync(string procedureName, params SqlParameter[] parameters)
        {
            using var connection = CreateConnection();
            using var command = new SqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddRange(parameters);
            await connection.OpenAsync();
            return await command.ExecuteNonQueryAsync();
        }

        public async Task<SqlDataReader> ExecuteReaderAsync(string procedureName, params SqlParameter[] parameters)
        {
            var connection = CreateConnection();
            using var command = new SqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddRange(parameters);
            await connection.OpenAsync();
            return await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }
    }
}
