using ePieHut.Entities;
using ePieHut.Repositories.Implentations;
using ePieHut.Repositories.Interfaces;
using ePieHut.Services.Implementations;
using ePieHut.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePieHut.Services
{
    public static class ConfigurationServices
    {
        public static void RegisterServices(IServiceCollection services,IConfiguration configuration)
        {
            //Database Configuration
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))

            );



            //Register Repositories DI
            services.AddScoped<IUserRepo, UserRepo>();

            //Authentication DI
            services.AddScoped<IAuthService, AuthService>();






        }





    }
}
