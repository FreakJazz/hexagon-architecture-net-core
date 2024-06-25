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

        public UserModel UpdateUser(UserModel updatedUser)
        {
            var existingUser = _context.User.Find(updatedUser.ID_USER);
            if (existingUser == null)
            {
                return null;
            }

            // Update the properties you want to change
            existingUser.NAME_USER = updatedUser.NAME_USER;
            existingUser.LASTNAME_USER = updatedUser.LASTNAME_USER;
            existingUser.EMAIL = updatedUser.EMAIL;
            existingUser.BORN_DATE = updatedUser.BORN_DATE;
            existingUser.ROLE = updatedUser.ROLE;
            existingUser.SEX = updatedUser.SEX;
            existingUser.DNI_USER = updatedUser.DNI_USER;
            existingUser.PHOTO_USER = updatedUser.PHOTO_USER;
            existingUser.UPDATED_AT = DateTime.UtcNow;

            _context.Entry(existingUser).Property("NAME_USER").IsModified = true;
            _context.Entry(existingUser).Property("LASTNAME_USER").IsModified = true;
            _context.Entry(existingUser).Property("EMAIL").IsModified = true;
            _context.Entry(existingUser).Property("BORN_DATE").IsModified = true;
            _context.Entry(existingUser).Property("ROLE").IsModified = true;
            _context.Entry(existingUser).Property("SEX").IsModified = true;
            _context.Entry(existingUser).Property("DNI_USER").IsModified = true;
            _context.Entry(existingUser).Property("PHOTO_USER").IsModified = true;
            _context.Entry(existingUser).Property("UPDATED_AT").IsModified = true;
            _context.SaveChanges();
            return existingUser;
        }

        public int DeleteUser(int id)
        {
            var user = _context.User.Find(id);
            if (user != null)
            {
                _context.User.Remove(user);
                return _context.SaveChanges();
            }
            return 0;
        }
    }


}
