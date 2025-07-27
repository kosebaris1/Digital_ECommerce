using D_Domain_Layer.Entities;
using D_Infrastructure_Layer.DTOs;
using D_Persistence_Layer.AppDbContext;
using D_Persistence_Layer.Model;
using D_Persistence_Layer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.Repositories.Repository
{
    public class MainCategoryRepository : Repository<MainCategory>, IMainCategoryRepository
    {

        public MainCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BaseResponseModel> CreateMainCategory(MainCategoryDTO model)
        {
           var result = await Add(new MainCategory 
           { 
               CategoryDescription = model.CategoryDescription,
               CategoryName = model.CategoryName
           });
            if(result != null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Main Category created successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Main Category created failed",
                Result = result
            };
        }

        public async Task<BaseResponseModel> GetAllMainCategories()
        {
            var result = await GetAll();
            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Main Categories retrieved successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "No Main Categories found",
                Result = null
            };
        }
    }
}
