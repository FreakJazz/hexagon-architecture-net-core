using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Contracts.Context
{
    public interface IContextDatabase : IDisposable
    {
        DbSet<UserModel> Users { get; set; }
        DbSet<AuthenticationModel.LoginModel> Login { get; set; }
        DbSet<AuthenticationModel.RegisterModel> Register { get; set; }
        int SaveChanges();
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null);
        Task<int> ExecuteAsync(string sql, object parameters = null);
    }
}
