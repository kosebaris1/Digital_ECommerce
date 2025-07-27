using D_Domain_Layer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain_Layer.Entities
{
    public class SubCategory : BaseEntity
    {
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        [ForeignKey("MainCategory")]
        public Guid MainCategoryId { get; set; }

        public virtual MainCategory MainCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
