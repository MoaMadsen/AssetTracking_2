using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
    internal class MyDbContext : DbContext
    {
        public DbSet<AssetItem> assetitems { get; set; }
        public DbSet<Currency> currencies { get; set; }

        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Database=AssetTracking;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Here we are adding seed data for Currency database. */
            modelBuilder.Entity<Currency>().HasData(new Currency {Country = "USA", Shorten = "USD", Rate = 1 });
            modelBuilder.Entity<Currency>().HasData(new Currency {Country = "Sweden", Shorten = "SEK", Rate = 9.9521 });
            modelBuilder.Entity<Currency>().HasData(new Currency {Country = "Spain", Shorten = "EUR", Rate = 0.9487 });
            modelBuilder.Entity<Currency>().HasData(new Currency {Country = "Denmark", Shorten = "DKK", Rate = 7.0784 });
            modelBuilder.Entity<Currency>().HasData(new Currency {Country = "Germany", Shorten = "EUR", Rate = 0.9487 });
            
            /* Here we are adding seed data for AssetItem database. */
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem {Id= 1,Type="Computer", Brand = "HP", Model = "Elitebook", CurrencyCountry = "Spain", PurchaseDate = 20190601, EndOfLife = 20220601,Price = 1423 });
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem { Id = 2, Type = "Computer", Brand = "HP", Model = "Elitebook", CurrencyCountry = "Denmark",PurchaseDate = 20200526,EndOfLife = 20230526,Price = 588 });
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem { Id = 3, Type = "Computer", Brand = "HP", Model = "Elitebook", CurrencyCountry = "Sweden",PurchaseDate = 20200316,EndOfLife = 20230316,Price = 588});
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem { Id = 4, Type = "Computer", Brand = "Asus",Model = "W234",CurrencyCountry = "Spain",PurchaseDate = 20190821,EndOfLife = 20220821,Price = 1200 });
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem { Id = 5, Type = "Computer", Brand = "Lenovo",Model = "Yoga 730",CurrencyCountry = "USA",PurchaseDate = 20170421,EndOfLife = 20200421,Price = 1035});
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem { Id = 6, Type = "Computer", Brand = "Lenovo",Model = "Yoga 530", CurrencyCountry = "USA",PurchaseDate = 20190521,EndOfLife = 20220521,Price = 835});
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem { Id = 7, Type = "Mobile", Brand = "iPhone",Model = "8",CurrencyCountry = "Spain",PurchaseDate = 20181229,EndOfLife = 20211229,Price = 970});
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem { Id = 8, Type = "Mobile", Brand = "iPhone",Model = "11",CurrencyCountry = "Spain",PurchaseDate = 20200925,EndOfLife = 20230925, Price = 990});
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem { Id = 9, Type = "Mobile", Brand = "Motorola",Model = "Razr",CurrencyCountry = "Sweden",PurchaseDate = 20200315,EndOfLife = 20230315,Price = 970});
            modelBuilder.Entity<AssetItem>().HasData(new AssetItem { Id = 10, Type = "Mobile", Brand = "iPhone",Model = "X",CurrencyCountry = "Sweden",PurchaseDate = 20180715,EndOfLife = 20210715,Price = 1245});
 
        }
    }
}
