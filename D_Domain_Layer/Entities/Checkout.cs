using D_Domain_Layer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain_Layer.Entities
{
    public class Checkout : BaseEntity
    {
        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpriyDate { get; set; }
        public string CVV { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
