using D_Infrastructure_Layer.DTOs;
using D_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.Repositories.Interface
{
    public interface IMainCategoryRepository
    {
       Task<BaseResponseModel> CreateMainCategory(MainCategoryDTO model);
        Task<BaseResponseModel> GetAllMainCategories();

    }
}
