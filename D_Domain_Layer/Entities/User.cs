using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain_Layer.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        //public string ConfirmPassword { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Checkout> Checkouts { get; set; }
    }
}
