using D_Domain_Layer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain_Layer.Entities
{
    public class MainCategory : BaseEntity
    {
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }

    }
}
