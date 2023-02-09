using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities
{
    public partial class Hmo
    {
        public int IdHmo { get; set; }

        public string Hmo1 { get; set; } = null!;

        public virtual ICollection<User> Users { get; } = new List<User>();
    }
}
