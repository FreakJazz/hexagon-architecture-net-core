using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPasswordHasherAppService : IDisposable
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);

    }
}
