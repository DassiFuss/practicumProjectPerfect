using Arch.EntityFrameworkCore;
using Properties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class IMockService
    {
        DbSet<User> users { get; set; }
    }
}
