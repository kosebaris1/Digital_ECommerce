using D_Core_Layer.Services.Abstract;
using D_Infrastructure_Layer.DTOs.Product;
using D_Persistence_Layer.Model;
using D_Persistence_Layer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Core_Layer.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<BaseResponseModel> AddProduct(ProductDTO product)
        {
           var result = _productRepository.AddProduct(product);
            return result;
        }

        public Task<BaseResponseModel> GetAllProducts()
        {
            var result = _productRepository.GetAllProducts();
            return result;
        }

        public Task<BaseResponseModel> GetProductById(Guid id)
        {
            var result = _productRepository.GetProductById(id);
            return result;
        }

        public Task<BaseResponseModel> RemoveProduct(Guid id)
        {
           var result = _productRepository.RemoveProduct(id);
            return result;
        }

        public Task<BaseResponseModel> UpdateProduct(UpdateProductDTO product)
        {
            var result = _productRepository.UpdateProduct(product);
            return result;
        }
    }
}
