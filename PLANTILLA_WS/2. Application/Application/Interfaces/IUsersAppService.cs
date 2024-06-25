using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IUsersAppService : IDisposable
    {
        public UserViewModel GetUserById(int userId);
        public IQueryable<UserViewModel> GetUsers();
        public UserViewModel GetUserByUsernameAndPassword(loginModel login);
        public UserViewModel RegisterUser(UserViewModel register);
    }
}
