namespace NWHarvest.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NWHarvestEntities : DbContext
    {
        public NWHarvestEntities()
            : base("name=NWHarvestEntities")
        {
        }

        public virtual DbSet<Grower> Farmers { get; set; }
        public virtual DbSet<FoodBank> FoodBanks { get; set; }
        public virtual DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grower>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Grower>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Grower>()
                .Property(e => e.email)
                .IsUnicode(false);
            modelBuilder.Entity<Grower>()
                .Property(e => e.address1)
                .IsUnicode(false);

            modelBuilder.Entity<Grower>()
                .Property(e => e.address2)
                .IsUnicode(false);

            modelBuilder.Entity<Grower>()
                .Property(e => e.address3)
                .IsUnicode(false);

            modelBuilder.Entity<Grower>()
                .Property(e => e.address4)
                .IsUnicode(false);

            modelBuilder.Entity<Grower>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Grower>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Grower>()
                .Property(e => e.zip)
                .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
               .Property(e => e.address1)
               .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
                .Property(e => e.address2)
                .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
                .Property(e => e.address3)
                .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
                .Property(e => e.address4)
                .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<FoodBank>()
                .Property(e => e.zip)
                .IsUnicode(false);

            modelBuilder.Entity<Listing>()
                .Property(e => e.product)
                .IsUnicode(false);

            modelBuilder.Entity<Listing>()
                .Property(e => e.qtyOffered)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Listing>()
                .Property(e => e.qtyClaimed)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Listing>()
                .Property(e => e.qtyLabel)
                .IsUnicode(false);

            modelBuilder.Entity<Listing>()
                .Property(e => e.cost)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Listing>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.address1)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.address2)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.address3)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.address4)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.zip)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.comments)
                .IsUnicode(false);
        }
    }
}
