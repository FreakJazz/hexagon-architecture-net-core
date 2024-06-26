using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers.Contracts
{
    public interface IRoleMapper
    {
        public IQueryable<RoleViewModel> MapRoles(IQueryable<RoleModel> items);
        public RoleViewModel MapRole(RoleModel roleModel);
        public RoleModel MapRoleInsert(RoleViewModel roleViewModel);
    }
}
