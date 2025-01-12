using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Models;
using PetShop.Domain.Models.Blog.Group;
using PetShop.Domain.Models.Orders;
using PetShop.Domain.Models.Products;
using PetShop.Domain.Models.Users;

namespace PetShop.Infra.Data.Context
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {
        }

        #region Fluent Api

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Groups>().HasOne(g => g.User).WithMany(u => u.Groups).
                HasForeignKey(g => g.UserIdOwner);

            modelBuilder.Entity<Comment>().HasOne(c => c.User)
                .WithMany(u => u.Comments).HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>().HasOne(c => c.Product)
              .WithMany(u => u.OrderDetails).HasForeignKey(c => c.ProdcutId)
              .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion Fluent Api

        #region DbSet

        public DbSet<User> User { get; set; }
        public DbSet<Groups> Group { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<About_Us> About_Us { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<User_Detail> User_Detail { get; set; }
        public DbSet<BlogGroup> BlogGroup { get; set; }
        public DbSet<Blog> Blog { get; set; }

        #endregion DbSet
    }
}