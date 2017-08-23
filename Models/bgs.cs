namespace Board_game_sleeves.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class bgs : DbContext
    {
        public bgs()
            : base("name=bgs")
        {
        }

        public virtual DbSet<BillingAddress> BillingAddresses { get; set; }
        public virtual DbSet<BoardGame> BoardGames { get; set; }
        public virtual DbSet<CardType> CardTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductMatchingBoardgame> ProductMatchingBoardgames { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillingAddress>()
                .Property(e => e.Contry)
                .IsUnicode(false);

            modelBuilder.Entity<BillingAddress>()
                .Property(e => e.Zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BillingAddress>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<BillingAddress>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<BillingAddress>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.BillingAddress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.ProductMatchingBoardgames)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CardType>()
                .Property(e => e.xSize)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CardType>()
                .Property(e => e.ySize)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CardType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CardType>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.CardType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastNAme)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ImageURL)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Material)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductMatchingBoardgames)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
