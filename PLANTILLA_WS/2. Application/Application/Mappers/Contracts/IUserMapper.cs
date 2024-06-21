using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers.Contracts
{
    public interface IUserMapper
    {
        public IQueryable<UserViewModel> MapUsers(IQueryable<UserModel> items);
        public UserViewModel MapUser(UserModel userModel);
        public AuthenticationModel.LoginModel MapLogin(AuthenticationViewModel.Login login);
        public AuthenticationModel.RegisterModel MapRegister(AuthenticationViewModel.Register register);
        public UserModel MapUserInsert(UserViewModel userViewModel);
        public AuthenticationViewModel.Register MapRegisterInsert(AuthenticationModel.RegisterModel register);
    }
}
