using D_Domain_Layer.Entities;
using D_Infrastructure_Layer;
using D_Persistence_Layer.AppDbContext;
using D_Persistence_Layer.MappingProfiles;
using D_Persistence_Layer.Model;
using D_Persistence_Layer.Repositories.Interface;
using D_Persistence_Layer.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer
{
    public static class ServiceRegistrations
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration Configuration = null)
        {
            services.AddScoped(typeof(BaseResponseModel));
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IMainCategoryRepository,MainCategoryRepository>();
            services.AddScoped<ISubCategoryRepository,SubCategoryRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductImageRepository,ProductImageRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddInfrastructureRegisterServices(Configuration);
            services.AddAutoMapper(typeof(MapperProfile));
        }   
    }
}
