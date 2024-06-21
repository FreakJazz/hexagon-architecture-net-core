using Application.Interfaces;
using Application.Mappers.Contracts;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using static Application.ViewModels.AuthenticationViewModel;

namespace Application.Services
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly IPasswordHasherAppService _passwordHasherAppService;

        public UsersAppService(IUserRepository userRepository, IUserMapper userMapper, IPasswordHasherAppService passwordHasherAppService)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
            _passwordHasherAppService = passwordHasherAppService;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public UserViewModel GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            return _userMapper.MapUser(user);
        }
        public IQueryable<UserViewModel> GetUsers()
        {
            var users = _userRepository.GetAllUsers();
            return _userMapper.MapUsers(users);
        }
        public AuthenticationViewModel.Register GetUserByUsernameAndPassword(AuthenticationViewModel.Login login)
        {
            var userModel = _userMapper.MapLogin(login);
            var user = _userRepository.GetUserByEmail(userModel);
            if (user == null || !_passwordHasherAppService.VerifyPassword(login.password, user.PASSWORD))
            {
                return null;
            }
            return _userMapper.MapRegisterInsert(user);
        }
        public AuthenticationViewModel.Register RegisterUser(AuthenticationViewModel.Register register)
        {
            var userModel = _userMapper.MapRegister(register);
            var user = _userRepository.RegisterUser(userModel);
            if (user == null)
            {
                return null;
            }
            return _userMapper.MapRegisterInsert(user);
        }
    }
}
