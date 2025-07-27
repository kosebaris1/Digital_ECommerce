using D_Domain_Layer.Entities;
using D_Domain_Layer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Infrastructure_Layer.DTOs.Product
{
    public class GetProductDTO
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductStock { get; set; }

        public Colors Color { get; set; }
        [ForeignKey(nameof(SubCategory))]
        public Guid SubCategoryId { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    }
}
