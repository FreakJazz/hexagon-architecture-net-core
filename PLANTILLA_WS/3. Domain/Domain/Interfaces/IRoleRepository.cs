
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRoleRepository
    {
        public IQueryable<RoleModel> GetAllRoles();

        public RoleModel AddRole(RoleModel roleModel);
        public RoleModel UpdateRole(RoleModel roleModel);
        public int DeleteRole(int id);

    }
}
