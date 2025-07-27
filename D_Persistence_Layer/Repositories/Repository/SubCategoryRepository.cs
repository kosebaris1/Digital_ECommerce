using AutoMapper;
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
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private readonly IMapper _mapper;
        public SubCategoryRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> CreateSubCategory(SubCategoryDTO subCategoryDTO)
        {
             var objMap= _mapper.Map<SubCategory>(subCategoryDTO);
            var result = await Add(objMap);
            if (result != null)
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
    }
}
