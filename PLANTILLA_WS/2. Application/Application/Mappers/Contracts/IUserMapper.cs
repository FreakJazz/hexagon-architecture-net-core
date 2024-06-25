using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers.Contracts
{
    public interface IUserMapper
    {
        public IQueryable<UserViewModel> MapUsers(IQueryable<UserModel> items);
        public UserModel MapRegister(UserViewModel register);
        public UserModel MapLogin(loginModel login);
        public UserViewModel MapUser(UserModel userModel);
        public UserViewModel MapRegisterInsert(UserModel register);
        public UserModel MapUserInsert(UserViewModel userViewModel);
    }
}
