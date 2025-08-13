using D_Persistence_Layer.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.Repositories.Interface
{
    public interface IProductImageRepository
    {
        Task<BaseResponseModel> UploadImageAsync(Guid productId,List<IFormFile> file);
    }
}
