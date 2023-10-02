using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<RepoKendoDbContext> options) : base(options)
        {
        }
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PossibleAmounts> PossibleAmountss { get; set; }
        public DbSet<Previous_Status> Previous_Statuses { get; set; }
        public DbSet<Status> Statuses { get; set; }


    }
}
