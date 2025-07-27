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
    public class MainCategoryService : IMainCategoryService
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        public MainCategoryService(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<BaseResponseModel> CreateMainCategory(MainCategoryDTO model)
        {
            var result = await _mainCategoryRepository.CreateMainCategory(model);
            return result;
        }

        public async Task<BaseResponseModel> GetMainCategories()
        {
            var result = await _mainCategoryRepository.GetAllMainCategories();
            return result;
        }
    }
}
