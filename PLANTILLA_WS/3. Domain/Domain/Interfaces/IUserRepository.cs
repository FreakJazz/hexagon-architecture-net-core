using Domain.Models;


namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public IQueryable<UserModel> GetAllUsers();
        public UserModel GetUserById(int id);
        public UserModel RegisterUser(UserModel registerModel);
        public UserModel GetUserByEmail(UserModel login);
        public string AddUser(UserModel user);
        public string UpdateUser(UserModel user);
        public string DeleteUser(int id);
    }
}
