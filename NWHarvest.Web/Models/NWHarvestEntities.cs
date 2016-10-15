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
                .HasMany(e => e.Listings)
                .WithRequired(e => e.Farmer)
                .HasForeignKey(e => e.listing_farmer)
                .WillCascadeOnDelete(false);

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
                .Property(e => e.latlong)
                .HasPrecision(9, 6);

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
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<PickupLocation>()
                .Property(e => e.latlong)
                .HasPrecision(9, 6);
        }
    }
}
