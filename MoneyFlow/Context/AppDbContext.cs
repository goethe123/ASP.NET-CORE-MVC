using System;
using Microsoft.EntityFrameworkCore;
using MoneyFlow.Entities;

namespace MoneyFlow.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet <User> User { get; set; }
    public DbSet <Service> Service { get; set; }
    public DbSet <Transaction> Transaction { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(e=>
        {
            e.HasKey("UserId");
            e.Property("UserId").ValueGeneratedOnAdd();

            e.HasData(
                new User {UserId=1, FullName="John Smith", Email="John@gmail.com", Password="123"}
            );
        });

         modelBuilder.Entity<Service>(e=>
        {
            e.HasKey("ServiceId");
            e.Property("ServiceId").ValueGeneratedOnAdd();

            e.HasOne(e=> e.user).WithMany(u=>u.Services).HasForeignKey(e=>e.UserId).OnDelete(DeleteBehavior.Restrict); 
        });


         modelBuilder.Entity<Transaction>(e=>
        {
            e.HasKey("TransactionId");
            e.Property("TransactionId").ValueGeneratedOnAdd();
            e.Property("Date").HasColumnType("date");
            e.Property("TotalAmount").HasColumnType("decimal(10,2)");

            e.HasOne(e=> e.service).WithMany().HasForeignKey(e=>e.ServiceId)
            .OnDelete(DeleteBehavior.Restrict); 
             
            e.HasOne(e=> e.user).WithMany(u=>u.Transactions).HasForeignKey(e=>e.UserId)
            .OnDelete(DeleteBehavior.Restrict); 
        });
    }



    

}
