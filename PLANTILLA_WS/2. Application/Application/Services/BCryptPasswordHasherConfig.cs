using Application.Interfaces;

namespace Services.Api.Configurations
{
    public class BCryptPasswordHasherConfig: IPasswordHasherAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
