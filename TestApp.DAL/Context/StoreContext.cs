﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApp.DAL.Entities;


namespace TestApp.DAL.Context
{
    public class StoreContext : IdentityDbContext<Users>
    {

        public StoreContext( DbContextOptions<StoreContext> options ):base(options) 
        {
            
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }

       public DbSet<PaymentProcess> PaymentProcesses { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .HasMany(p => p.Ratings)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Categories>()
         .HasMany(c => c.Products)
         .WithOne(p => p.Category)
         .HasForeignKey(p => p.CategoryId)
         .OnDelete(DeleteBehavior.SetNull);



         

            base.OnModelCreating(modelBuilder);


            // Other configurations
        }


    }
}
