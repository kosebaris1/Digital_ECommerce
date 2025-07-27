using D_Domain_Layer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain_Layer.Entities
{
    public class Order : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Checkout))]
        public Guid CheckoutId { get; set; }
        public virtual Checkout Checkout { get; set; }
    }
}
