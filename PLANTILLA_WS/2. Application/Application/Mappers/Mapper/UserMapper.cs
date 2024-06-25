using Application.Mappers.Contracts;
using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers.Mapper
{
    public class UserMapper : IUserMapper
    {
        public IQueryable<UserViewModel> MapUsers(IQueryable<UserModel> items)
        {
            var lst = new List<UserViewModel>();
            foreach (var item in items)
            {
                lst.Add(new UserViewModel()
                {
                    idUser = item.ID_USER,
                    CreatedAt = item.CREATED_AT,
                    UpdatedAt = item.UPDATED_AT,
                    nameUser = item.NAME_USER,
                    lastnameUser = item.LASTNAME_USER,
                    email = item.EMAIL,
                    bornDate = item.BORN_DATE,
                    role = item.ROLE,
                    sex = item.SEX,
                    dniUser = item.DNI_USER,
                    photoUser = item.PHOTO_USER,
                });
            }
            return lst.AsQueryable();
        }
        public UserViewModel MapUser(UserModel userModel)
        {
            var userViewModel = new UserViewModel
            {
                idUser = userModel.ID_USER,
                CreatedAt = userModel.CREATED_AT,
                UpdatedAt = userModel.UPDATED_AT,
                nameUser = userModel.NAME_USER,
                lastnameUser = userModel.LASTNAME_USER,
                email = userModel.EMAIL,
                password = userModel.PASSWORD,
                bornDate = userModel.BORN_DATE,
                role = userModel.ROLE,
                sex = userModel.SEX,
                dniUser = userModel.DNI_USER,
                photoUser = userModel.PHOTO_USER,
            };
            return userViewModel;
        }
        public UserModel MapUserInsert(UserViewModel userViewModel)
        {
            var userModel = new UserModel
            {
                ID_USER = userViewModel.idUser,
                CREATED_AT = userViewModel.CreatedAt,
                UPDATED_AT = userViewModel.UpdatedAt,
                NAME_USER = userViewModel.nameUser,
                LASTNAME_USER = userViewModel.lastnameUser,
                EMAIL = userViewModel.email,
                BORN_DATE = userViewModel.bornDate,
                ROLE = userViewModel.role,
                SEX = userViewModel.sex,
                DNI_USER = userViewModel.dniUser,
                PHOTO_USER = userViewModel.photoUser,
            };
            return userModel;
        }
        public UserModel MapLogin(loginModel login)
        {
            var userModel = new UserModel
            {
                EMAIL = login.email,
                PASSWORD = login.password,
            };
            return userModel;
        }
        public UserModel MapRegister(UserViewModel register)
        {
            var registerModel = new UserModel
            {
                NAME_USER = register.nameUser,
                LASTNAME_USER = register.lastnameUser,
                EMAIL = register.email,
                PASSWORD = register.password,
                BORN_DATE = register.bornDate,
                ROLE = register.role,
                SEX = register.sex,
                DNI_USER = register.dniUser,
            };
            return registerModel;
        }

        public UserViewModel MapUserGet(UserModel register)
        {
            var registerModel = new UserViewModel
            {
                idUser = register.ID_USER,
                nameUser = register.NAME_USER,
                lastnameUser = register.LASTNAME_USER,
                email = register.EMAIL,
                bornDate = register.BORN_DATE,
                role = register.ROLE,
                sex = register.SEX,
                dniUser = register.DNI_USER,
                photoUser = register.PHOTO_USER
            };
            return registerModel;
        }
    }
}
