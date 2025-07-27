using D_Core_Layer.Services.Abstract;
using D_Core_Layer.Services.Concrete;
using D_Domain_Layer.Entities;
using D_Persistence_Layer;
using D_Persistence_Layer.AppDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Core_Layer
{
    public static class ServiceRegistrations
    {
        public static void AddCoreRegisterServices(this IServiceCollection services,IConfiguration Configuration = null)
        {
            services.AddPersistenceServiceRegistration(Configuration);
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IMainCategoryService,MainCategoryService>();
            services.AddScoped<ISubCategoryService,SubCategoryService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}