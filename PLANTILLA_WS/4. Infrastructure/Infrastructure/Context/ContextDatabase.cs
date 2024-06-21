﻿using Npgsql;
using Dapper;
using Infrastructure.Contracts.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using static Domain.Models.AuthenticationModel;

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
        public DbSet<AuthenticationModel.LoginModel> Login { get; set; }
        public DbSet<AuthenticationModel.RegisterModel> Register { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración explícita de los nombres de las tablas
            modelBuilder.Entity<AuthenticationModel.LoginModel>().ToTable("Users");
            modelBuilder.Entity<AuthenticationModel.RegisterModel>().ToTable("Users");
            modelBuilder.Entity<UserModel>().ToTable("Users");

            // Configurar LoginModel como una entidad sin clave
            modelBuilder.Entity<AuthenticationModel.LoginModel>().HasNoKey();
            modelBuilder.Entity<RegisterModel>().HasKey(r => r.ID_USER);
            modelBuilder.Entity<UserModel>().HasNoKey();
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
