using Application.Mappers.Contracts;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Mapper
{
    public class RoleMapper : IRoleMapper
    {
        public IQueryable<RoleViewModel> MapRoles(IQueryable<RoleModel> items)
        {
            var lst = new List<RoleViewModel>();
            foreach (var item in items)
            {
                lst.Add(new RoleViewModel()
                {
                    idRole = item.ID_ROLE,
                    createdAt = item.CREATED_AT,
                    updatedAt = item.UPDATED_AT,
                    nameRole = item.NAME_ROLE,
                    descRole = item.DESC_ROLE,
                    
                });
            }
            return lst.AsQueryable();
        }
        public RoleViewModel MapRole(RoleModel roleModel)
        {
            var roleViewModel = new RoleViewModel
            {
                idRole = roleModel.ID_ROLE,
                createdAt = roleModel.CREATED_AT,
                updatedAt = roleModel.UPDATED_AT,
                nameRole = roleModel.NAME_ROLE,
                descRole = roleModel.DESC_ROLE,
            };
            return roleViewModel;
        }
        public RoleModel MapRoleInsert(RoleViewModel roleViewModel)
        {
            var roleModel = new RoleModel
            {
                ID_ROLE = roleViewModel.idRole,
                CREATED_AT = roleViewModel.createdAt,
                UPDATED_AT = roleViewModel.updatedAt,
                NAME_ROLE = roleViewModel.nameRole,
                DESC_ROLE = roleViewModel.descRole,
            };
            return roleModel;
        }
    }
}
