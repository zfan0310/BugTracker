using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Created = DateTime.Now;
            this.IsRemoved = false;
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; }
        public bool IsRemoved { get; set; }
    }
}
