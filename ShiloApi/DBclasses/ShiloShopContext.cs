using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using ClassLibrary1;
namespace ShiloApi
{
    //A class that creates a communication structure instance with the database 
    //according to the relationships of the database in a way that conforms to SQL
    public class ShiloShopContext :DbContext
    {
        //Create the tables according to the classes
        public DbSet<Custumer> Customers { get; set; }
        public DbSet<Prodacts> Prodacts { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Orders> Orders { get; set; }
        // The connection key according to the string presented creates the 
        //connection with the database of the subjects
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:8-1-1990.database.windows.net,1433;Initial Catalog=ShiloShop;Persist Security Info=False;User ID=shilobiton;Password=12qwaszx$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // The conditions  which the table will be
            modelBuilder.Entity<Custumer>(relatens =>
            {
                relatens.Property("CustumerID").ValueGeneratedNever();
                relatens.Property("name").IsRequired().HasMaxLength(30);
                relatens.HasIndex("name").IsUnique();
                relatens.HasMany(cust => cust.orders);

            });
            modelBuilder.Entity<Prodacts>(relatens =>
            {

                relatens.Property("bandName").IsRequired().HasMaxLength(16);
                relatens.Property("Link").IsRequired();
                relatens.HasIndex("bandName").IsUnique();
            });
            modelBuilder.Entity<Orders>(relatens =>
            {
                //relatens.HasNoKey();
                relatens.Property("date").IsRequired();
                
               
            });
            modelBuilder.Entity<Students>(relatnes =>
            {
                relatnes.Property("date").IsRequired();
                relatnes.Property("Name").IsRequired();
                
            });

            


        }

   
    }


}
