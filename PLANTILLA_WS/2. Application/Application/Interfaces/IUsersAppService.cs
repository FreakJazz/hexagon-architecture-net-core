using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IUsersAppService : IDisposable
    {
        public UserViewModel GetUserById(int userId);
        public IQueryable<UserViewModel> GetUsers();
        public AuthenticationViewModel.Register GetUserByUsernameAndPassword(AuthenticationViewModel.Login login);
        public AuthenticationViewModel.Register RegisterUser(AuthenticationViewModel.Register register);
    }
}
