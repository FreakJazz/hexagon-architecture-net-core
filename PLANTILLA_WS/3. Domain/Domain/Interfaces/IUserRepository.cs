using Domain.Models;


namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public IQueryable<UserModel> GetAllUsers();
        public UserModel GetUserById(int id);
        public AuthenticationModel.RegisterModel RegisterUser(AuthenticationModel.RegisterModel registerModel);
        public AuthenticationModel.RegisterModel GetUserByEmail(AuthenticationModel.LoginModel login);
        public string AddUser(UserModel user);
        public string UpdateUser(UserModel user);
        public string DeleteUser(int id);
    }
}
