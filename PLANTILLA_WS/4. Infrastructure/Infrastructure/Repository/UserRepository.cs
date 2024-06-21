using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Contracts.Context;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logs;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    
    public class UserRepository : IUserRepository
    {
        private readonly IContextDatabase _context;
        protected readonly ILogger<ExceptionHandler> _logger;

        public UserRepository(ContextDatabase context)
        {
            _context = context;
        }

        public IQueryable<UserModel> GetAllUsers()
        {
            return _context.Users.AsQueryable();
        }

        public UserModel GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public AuthenticationModel.RegisterModel RegisterUser(AuthenticationModel.RegisterModel registerModel)
        {
            _context.Register.Add(registerModel);
            _context.SaveChanges();
            return registerModel;
        }

        public AuthenticationModel.RegisterModel GetUserByEmail(AuthenticationModel.LoginModel login)
        {
            return _context.Register.Find(login.EMAIL);
        }

        public string AddUser(UserModel user)
        {
             _context.Users.Add(user);
             _context.SaveChanges();
            return "Save";
        }

        public string AddUserRegister(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return "Save";
        }

        public string UpdateUser(UserModel user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return "Save";

        }

        public string DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return "Save";

        }
    }


}
