
using Application.Interfaces;
using Application.Mappers.Contracts;
using Application.ViewModels;
using Domain.Interfaces;

namespace Application.Services
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleMapper _roleMapper;

        public RoleAppService(IRoleRepository roleRepository, IRoleMapper roleMapper)
        {
            _roleRepository = roleRepository;
            _roleMapper = roleMapper;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public IQueryable<RoleViewModel> GetRoles()
        {
            var roles = _roleRepository.GetAllRoles();
            if (roles == null)
            {
                return null;
            }
            return _roleMapper.MapRoles(roles);
        }
        public RoleViewModel AddRole(RoleViewModel roleViewModel)
        {
            var roleModel = _roleMapper.MapRoleInsert(roleViewModel);
            var role = _roleRepository.AddRole(roleModel);
            return _roleMapper.MapRole(role);
        }
        public RoleViewModel UpdateRole(RoleViewModel roleViewModel)
        {
            var roleModel = _roleMapper.MapRoleInsert(roleViewModel);
            var role = _roleRepository.UpdateRole(roleModel);
            return _roleMapper.MapRole(role);
        }
        public int DeleteRole(int id)
        {
            return _roleRepository.DeleteRole(id);
        }


    }
}
