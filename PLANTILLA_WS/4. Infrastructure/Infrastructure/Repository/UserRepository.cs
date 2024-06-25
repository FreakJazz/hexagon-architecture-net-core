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
using Microsoft.EntityFrameworkCore;

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
            return _context.User.AsQueryable();
        }

        public UserModel GetUserById(int id)
        {
            return _context.User.Find(id);
        }

        public UserModel RegisterUser(UserModel registerModel)
        {
            registerModel.CREATED_AT = DateTime.UtcNow;
            registerModel.UPDATED_AT = DateTime.UtcNow;
            //registerModel.BORN_DATE = registerModel.BORN_DATE.ToUniversalTime();
            _context.User.Add(registerModel);
            _context.SaveChanges();
            return registerModel;
        }

        public UserModel GetUserByEmail(UserModel login)
        {
            return _context.User.FirstOrDefault(u => u.EMAIL == login.EMAIL);
        }

        public string AddUser(UserModel user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return "Save";
        }

        public string AddUserRegister(UserModel user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return "Save";
        }

        public string UpdateUser(UserModel user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
            return "Save";

        }

        public string DeleteUser(int id)
        {
            var user = _context.User.Find(id);
            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
            }
            return "Save";
        }
    }


}
