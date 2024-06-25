using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Contracts.Context
{
    public interface IContextDatabase : IDisposable
    {
        //DbSet<UserModel> Users { get; set; }
        //DbSet<AuthenticationModel.LoginModel> Login { get; set; }
        DbSet<UserModel> User { get; set; }
        EntityEntry Entry(object entity);
        int SaveChanges();
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null);
        Task<int> ExecuteAsync(string sql, object parameters = null);
    }
}
