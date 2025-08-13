using D_Domain_Layer.Entities;
using D_Persistence_Layer.AppDbContext;
using D_Persistence_Layer.Model;
using D_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.Repositories.Repository
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BaseResponseModel> UploadImageAsync(Guid productId, List<IFormFile> file)
        {
            if (file.Count == 0 || file is null)
            {
                return new BaseResponseModel()
                {
                   Success = false,
                   Message = "No files provided for upload."
                };
            }

            var uploadDirectory = Path.Combine("wwroot","images");
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);

            }

            var uploadImage= new List<ProductImage>();
            foreach(var item in file)
            {
              var filePath = Path.Combine("wwroot/images", item.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }

                uploadImage.Add(new ProductImage()
                {
                    ProductId = productId,
                    ImageUrl = filePath
                });
            }

            var result = await AddRange(uploadImage);
            if (result is not null && result.Count > 0)
            {
                return new BaseResponseModel()
                {
                    Success = true,
                    Message = "Images uploaded successfully."
                };
            }
            else
            {
                return new BaseResponseModel()
                {
                    Success = false,
                    Message = "Images uploaded failed."
                };
            }

        }
    }
}
