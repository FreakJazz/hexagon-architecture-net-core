using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoleAppService
    {
        public IQueryable<RoleViewModel> GetRoles();
        public RoleViewModel AddRole(RoleViewModel roleViewModel);
        public RoleViewModel UpdateRole(RoleViewModel roleViewModel);
        public int DeleteRole(int id);
    }
}
