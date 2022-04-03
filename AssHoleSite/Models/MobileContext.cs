using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssHoleSite.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<PhoneC> Phones { get; set; }
        public DbSet<CategoryC> Categories { get; set; }
        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
