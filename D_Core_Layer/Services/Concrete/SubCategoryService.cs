using D_Core_Layer.Services.Abstract;
using D_Infrastructure_Layer.DTOs;
using D_Persistence_Layer.Model;
using D_Persistence_Layer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Core_Layer.Services.Concrete
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }
        public async Task<BaseResponseModel> CreateSubCategory(SubCategoryDTO subCategoryDTO)
        {
            var result = await _subCategoryRepository.CreateSubCategory(subCategoryDTO);
            return result;
        }
    }
}
