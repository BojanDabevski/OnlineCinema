using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCinemaApp.Domain.DomainModels;
using OnlineCinemaApp.Domain.Identity;
using System;

namespace OnlineCinemaApp.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            //builder.Entity<ProductInShoppingCart>()
            //   .HasKey(z => new { z.ProductId, z.ShoppingCartId });

            //builder.Entity<ProductInShoppingCart>().HasOne(z => z.ShoppingCart).WithMany(z => z.ProductInShoppingCarts).HasForeignKey(z => z.ShoppingCartId);
            //builder.Entity<ProductInShoppingCart>().HasOne(z => z.Product).WithMany(z => z.ProductInShoppingCarts).HasForeignKey(z => z.ProductId);
            // izmegju
            
           builder.Entity<ProductInShoppingCart>()
                .HasOne(z => z.Product)
                .WithMany(z => z.ProductInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

           builder.Entity<ProductInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
               .WithMany(z => z.Products)
                .HasForeignKey(z => z.ProductId);


            builder.Entity<ShoppingCart>()
                .HasOne<ApplicationUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);


            //builder.Entity<ProductInOrder>()
            //  .HasKey(z => new { z.ProductId, z.OrderId });

            builder.Entity<ProductInOrder>()
                .HasOne(z => z.SelectedProduct)
                .WithMany(z => z.Orders)
                .HasForeignKey(z => z.OrderId);

            builder.Entity<ProductInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.Products)
                .HasForeignKey(z => z.ProductId);


        }
    }
}
