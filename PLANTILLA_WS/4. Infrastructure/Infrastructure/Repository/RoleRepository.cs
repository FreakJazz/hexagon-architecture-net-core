using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Contracts.Context;
using Domain.Interfaces;
using Common.Logs;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IContextDatabase _context;
        protected readonly ILogger<ExceptionHandler> _logger;

        public RoleRepository(ContextDatabase context)
        {
            _context = context;
        }
        public IQueryable<RoleModel> GetAllRoles()
        {
            return _context.Roles.AsQueryable();
        }

        public RoleModel AddRole(RoleModel roleModel)
        {
            roleModel.CREATED_AT = DateTime.UtcNow;
            roleModel.UPDATED_AT = DateTime.UtcNow;
            _context.Roles.Add(roleModel);
            _context.SaveChanges();
            return roleModel;
        }
        public RoleModel UpdateRole(RoleModel roleModel)
        {
            var existingRole = _context.Roles.Find(roleModel.ID_ROLE);
            if (existingRole == null)
            {
                return null;
            }

            // Update the properties you want to change
            existingRole.NAME_ROLE = roleModel.NAME_ROLE;
            existingRole.DESC_ROLE = roleModel.DESC_ROLE;
            existingRole.UPDATED_AT = DateTime.UtcNow;

            _context.Entry(existingRole).Property("NAME_ROLE").IsModified = true;
            _context.Entry(existingRole).Property("DESC_ROLE").IsModified = true;
            _context.Entry(existingRole).Property("UPDATED_AT").IsModified = true;
            _context.SaveChanges();
            return existingRole;
        }

        public int DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                return _context.SaveChanges();
            }
            return 0;
        }

    }
}
