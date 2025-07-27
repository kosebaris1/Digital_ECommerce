using D_Domain_Layer.Entities;
using D_Infrastructure_Layer.DTOs.Product;
using D_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<BaseResponseModel> GetAllProducts();

        Task<BaseResponseModel> GetProductById(Guid id);

        Task<BaseResponseModel> RemoveProduct(Guid id);

        Task<BaseResponseModel> AddProduct(ProductDTO product);
        Task<BaseResponseModel> UpdateProduct(Guid id,ProductDTO product);
    }
}
