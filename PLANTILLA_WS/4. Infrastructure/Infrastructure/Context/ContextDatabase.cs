using System.Data;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using Infrastructure.Contracts.Context;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class ContextDatabase : IContextDatabase
    {
        private readonly IConfiguration _configuration;
        public ContextDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("PostgreSQLDb").Value);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
