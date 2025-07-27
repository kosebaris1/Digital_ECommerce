using AutoMapper;
using D_Domain_Layer.Entities;
using D_Infrastructure_Layer.DTOs.Product;
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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> AddProduct(ProductDTO productDTO)
        {
            var values = _mapper.Map<Product>(productDTO);
            var result = await Add(values);
            if(result != null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Product added successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Product added failed",
            };
        }

        public async Task<BaseResponseModel> GetAllProducts()
        {
           IEnumerable<Product> products = await GetAll();
            var objMap= _mapper.Map<IEnumerable<GetProductDTO>>(products);
            if (objMap != null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Products retrieved successfully",
                    Result = objMap
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "No products found"
            };
        }

        public async Task<BaseResponseModel> GetProductById(Guid id)
        {
            Product product = await GetById(id);
            var objMap= _mapper.Map<GetProductDTO>(product);
            if (objMap != null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Products retrieved successfully",
                    Result = objMap
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "No products found"
            };
        }

        public async Task<BaseResponseModel> RemoveProduct(Guid id)
        {
            await Delete(id);
            return new BaseResponseModel
            {
                Success = true,
                Message = "Product removed successfully"
            };

        }

        public async Task<BaseResponseModel> UpdateProduct(Guid id, ProductDTO productDTO)
        {
            var objMap = _mapper.Map<Product>(productDTO);
            var result = await Update(id, objMap);
            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Product updated successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Product updated failed",
            };
        }
    }
}
