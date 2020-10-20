using EgenOrderingSystem.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.DBContext
{
    public class OrderSystemContext : DbContext
    {
        public OrderSystemContext(DbContextOptions<OrderSystemContext> options)
            : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cards> Cards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryMethods> DeliveryMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<OrderPaymentDetails> OrderPaymentDetails { get; set; }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = 1,
                    FirstName = "Berry",
                    LastName = "Griffin Beak Eldritch",
                    EmailID = "ravi.katakum@gmail.com",
                });
                modelBuilder.Entity<Cards>().HasData(
                new Cards()
                {
                    Id = 1,
                    CardNumber = 11111111111111,
                    Month = 12,
                    Year = 24,
                    Cvv = 500,
                    Name = "ravi katakum",
                });
            modelBuilder.Entity<Address>().HasData(
                new Address()
                {
                    Id = 1,
                    AddressLine1 = "650 Lowell Ave",
                    City = "Cincnnati",
                    State ="OH",
                    Zip=45249,
                });
            modelBuilder.Entity<DeliveryMethods>().HasData(
                new DeliveryMethods()
                {
                    Id = 1,
                    Name = "CurbSide",
                    Cost = 0,
                });
            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id = 1,
                    CustomerId = 1,
                    //BillingAddress=1,
                    AddressID =1,
                    DeliveryMethodId=1,
                    CreationDate = new DateTime(2020,10,10),
                    OrderDate=new DateTime(2020,10,10),
                    Status="Confirmed",
                    Subtotal=1000,
                    Tax=100,
                    Total=1100,                    
                });
            modelBuilder.Entity<Products>().HasData(
                new Products()
                {
                    Id = 1,
                    Name = "Iphone",
                    Price = 1000,
                });
            modelBuilder.Entity<OrderItems>().HasData(
                new OrderItems()
                {
                    Id = 1,
                    ProductsId = 1,
                    OrderId = 1,
                    Quantity = 1
                });
            modelBuilder.Entity<OrderPayment>().HasData(
                new OrderPayment()
                {
                    Id = 1,
                    ConfirmationNumber = 12345,
                    
                });
            modelBuilder.Entity<OrderPaymentDetails>().HasData(
                new OrderPaymentDetails()
                {
                    Id = 1,
                    Amount = 1000,
                    CardId = 1,
                    OrderId = 1,
                    OrderPaymentId = 1
                });
        }
    }
}
