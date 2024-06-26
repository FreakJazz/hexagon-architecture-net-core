using Application.Interfaces;
using Application.Mappers.Contracts;
using Application.ViewModels;
using Domain.Interfaces;

namespace Application.Services
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UsersAppService(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public UserViewModel GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            return _userMapper.MapUserGet(user);
        }
        public IQueryable<UserViewModel> GetUsers()
        {
            var users = _userRepository.GetAllUsers();
            return _userMapper.MapUsers(users);
        }
        public UserViewModel GetUserByUsernameAndPassword(loginModel login)
        {
            var userModel = _userMapper.MapLogin(login);
            var user = _userRepository.GetUserByEmail(userModel);
            if (user == null)
            {
                return null;
            }
            return _userMapper.MapUser(user);
        }
        public UserViewModel UpdateUser(UserViewModel userUpdate)
        {
            var userModel = _userMapper.MapUserInsert(userUpdate);
            var user = _userRepository.UpdateUser(userModel);
            if (user == null)
            {
                return null;
            }
            return _userMapper.MapUserGet(user);
        }
        public UserViewModel RegisterUser(UserViewModel register)
        {
            var userModel = _userMapper.MapRegister(register);
            var user = _userRepository.RegisterUser(userModel);
            if (user == null)
            {
                return null;
            }
            return _userMapper.MapUserGet(user);
        }
    }
}
