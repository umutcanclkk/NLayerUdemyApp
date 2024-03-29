﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Models;
using System.Reflection;

namespace NLayerRepository
{
    public class AppDbContext:DbContext
    {
       

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        
        }


        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Customers> Customers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());




            base.OnModelCreating(modelBuilder);
        }




    }



}
