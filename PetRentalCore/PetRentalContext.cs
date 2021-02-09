using Microsoft.EntityFrameworkCore;
using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRentalCore
{
    public class PetRentalContext : DbContext {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PetRental");
        }
        public DbSet<Rental> Rentals {
            get; private set;
        }
        public DbSet<Accessory> Accessories {
            get; private set;
        }
        public DbSet<Client> Clients {
            get; private set;
        }
        public DbSet<PetType> PetTypes {
            get; private set;
        }

        public DbSet<Size> Sizes {
            get; private set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Size>().HasData(new Size() {Id = 1, SizeName = Size.SizeType.XS});
            modelBuilder.Entity<Size>().HasData(new Size() {Id = 2, SizeName = Size.SizeType.S});
            modelBuilder.Entity<Size>().HasData(new Size() {Id = 3, SizeName = Size.SizeType.M});
            modelBuilder.Entity<Size>().HasData(new Size() {Id = 4, SizeName = Size.SizeType.L});
            modelBuilder.Entity<Size>().HasData(new Size() {Id = 5, SizeName = Size.SizeType.XL});

            modelBuilder.Entity<PetType>().HasData(new PetType() { Id = 1, PetTypeName = "Dog" });
            modelBuilder.Entity<PetType>().HasData(new PetType() { Id = 2, PetTypeName = "Cat" });
            modelBuilder.Entity<PetType>().HasData(new PetType() { Id = 3, PetTypeName = "Parrot" });
            modelBuilder.Entity<PetType>().HasData(new PetType() { Id = 4, PetTypeName = "Mouse" });
            modelBuilder.Entity<PetType>().HasData(new PetType() { Id = 5, PetTypeName = "Rat" });
            modelBuilder.Entity<PetType>().HasData(new PetType() { Id = 6, PetTypeName = "Hamster" });
            modelBuilder.Entity<PetType>().HasData(new PetType() { Id = 7, PetTypeName = "Horse" });
            modelBuilder.Entity<PetType>().HasData(new PetType() { Id = 8, PetTypeName = "Pig" });
            
            modelBuilder.Entity<Client>().HasData(new Client() { Id = 1, Name = "Katarzyna", Surname = "Jablonska", DateOfBirth = new DateTime(1995, 03, 20), RegistrationDate = DateTime.Now });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 1, AccessoryName = "Kurtka Randig", OneDayRentalPrice = 10.00m, PetTypeId = 1, SizeId = 1 });
        }
    }
}
