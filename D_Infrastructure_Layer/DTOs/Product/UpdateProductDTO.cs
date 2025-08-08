using D_Domain_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Infrastructure_Layer.DTOs.Product
{
    public class UpdateProductDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductStock { get; set; }

        public Colors Color { get; set; }
        public Guid SubCategoryId { get; set; }
    }
}
