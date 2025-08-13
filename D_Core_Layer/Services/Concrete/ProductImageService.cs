using D_Core_Layer.Services.Abstract;
using D_Persistence_Layer.Model;
using D_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Core_Layer.Services.Concrete
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public Task<BaseResponseModel> UploadImageAsync(Guid productId, List<IFormFile> file)
        {
           var result= _productImageRepository.UploadImageAsync(productId, file);
            return result;
        }
    }
}
