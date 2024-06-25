using Npgsql;
using Dapper;
using Infrastructure.Contracts.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Context
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        private readonly IConfiguration _configuration;
        public ContextDatabase(DbContextOptions<ContextDatabase> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<UserModel> User { get; set; }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración explícita de los nombres de las tablas
            modelBuilder.Entity<UserModel>().ToTable("User");

            // Configurar LoginModel como una entidad sin clave
            modelBuilder.Entity<UserModel>().HasKey(r => r.ID_USER);
        }

        public new Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQLDb")))
            {
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQLDb")))
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
