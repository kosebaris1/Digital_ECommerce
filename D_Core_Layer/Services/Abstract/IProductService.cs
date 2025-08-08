using D_Infrastructure_Layer.DTOs.Product;
using D_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Core_Layer.Services.Abstract
{
    public interface IProductService
    {
        Task<BaseResponseModel> GetAllProducts();

        Task<BaseResponseModel> GetProductById(Guid id);

        Task<BaseResponseModel> RemoveProduct(Guid id);

        Task<BaseResponseModel> AddProduct(ProductDTO product);
        Task<BaseResponseModel> UpdateProduct(UpdateProductDTO product);
    }
}
