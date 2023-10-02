using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PossibleAmounts> PossibleAmountss { get; set; }
        public DbSet<Previous_Status> Previous_Statuses { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>()
                 .HasIndex(x => x.date);
            modelBuilder.Entity<PossibleAmounts>()
                .HasIndex(x => x.IsActive); 
            modelBuilder.Entity<PossibleAmounts>()
                .HasIndex(x =>x.OfferID); 
            modelBuilder.Entity<PossibleAmounts>()
                .HasIndex(x => x.AmountID );
            modelBuilder.Entity<Amount>()
                .HasKey(x =>  x.ID );
            modelBuilder.Entity<Amount>()
                .HasKey(x =>  x.Buyer_ID );
            modelBuilder.Entity<Buyer>()
                .HasKey(x => x.ID);
            modelBuilder.Entity<Previous_Status>()
                .HasIndex(x => x.IsActive);  
            modelBuilder.Entity<Previous_Status>()
                .HasIndex(x =>  x.OfferID );
            modelBuilder.Entity<Status>()
                .HasKey(x => x.ID);
        }
    }
}
