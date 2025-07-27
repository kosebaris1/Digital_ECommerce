using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain_Layer.Base
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
