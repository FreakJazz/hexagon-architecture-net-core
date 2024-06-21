using Application.Interfaces;
using Application.Mappers.Contracts;
using Application.Mappers.Mapper;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Contracts.Context;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Services.Api.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting
{
    public class IocRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            #region Mappers
            services.AddScoped<IUserMapper, UserMapper>();
            #endregion
            #region AppServices
            services.AddScoped<IUsersAppService, UsersAppService>();
            services.AddScoped<IPasswordHasherAppService, BCryptPasswordHasherConfig>();
            #endregion
            #region AppServices
            //Domain - Events
            //Domain - Commands
            //Infrastructure
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContextDatabase, ContextDatabase>();
            #endregion
        }
    }
}
