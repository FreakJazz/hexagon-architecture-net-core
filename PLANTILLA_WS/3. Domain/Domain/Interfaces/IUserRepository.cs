using Domain.Models;


namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public IQueryable<UserModel> GetAllUsers();
        public UserModel GetUserById(int id);
        public UserModel RegisterUser(UserModel registerModel);
        public UserModel GetUserByEmail(UserModel login);
        public UserModel UpdateUser(UserModel user);
        public int DeleteUser(int id);
    }
}
