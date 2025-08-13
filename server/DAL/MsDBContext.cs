using Microsoft.EntityFrameworkCore;
using MSMA.Models;

namespace MSMA.DAL
{
    public class MsDBContext : DbContext
    {
        public MsDBContext(DbContextOptions<MsDBContext> options) : base(options)
        {
            
        }
        public DbSet<Donors> donors { get; set; }
        public DbSet<Gifts> gifts { get; set; }

        public DbSet<Users> users { get; set; }
        public DbSet<Cards> cards { get; set; }
        public DbSet<Orders> orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



        }


        //public OrdersDBContex(DbContextOptions<OrdersDBContex> options) : base(options)
        //{

        //}

        //public DbSet<Order> Order { get; set; }
        //public DbSet<Customer> Customer { get; set; }
        //public DbSet<OrderDetailes> OrderDetails { get; set; }
        //public DbSet<Product> Product { get; set; }
        //public DbSet<Contacts> Contacts { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>().Property(p => p.Id).UseIdentityColumn(10, 10);


        //}
    }
}
