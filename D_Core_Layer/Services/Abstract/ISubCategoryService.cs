using D_Infrastructure_Layer.DTOs;
using D_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Core_Layer.Services.Abstract
{
    public interface ISubCategoryService
    {
        Task<BaseResponseModel> CreateSubCategory(SubCategoryDTO subCategoryDTO);
    }
}
