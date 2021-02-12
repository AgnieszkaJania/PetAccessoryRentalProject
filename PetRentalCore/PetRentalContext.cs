using Microsoft.EntityFrameworkCore;
using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetRentalCore
{
    public class PetRentalContext : DbContext {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PetRental");
            string path = Path.Combine(Environment.CurrentDirectory, "PetRental.mdf");
            
            optionsBuilder.UseSqlServer($@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName={path}");
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
        public static void Main() {

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
            modelBuilder.Entity<Client>().HasData(new Client() { Id = 2, Name = "Agnieszka", Surname = "Nowak", DateOfBirth = new DateTime(1996, 05, 23), RegistrationDate = DateTime.Now });
            modelBuilder.Entity<Client>().HasData(new Client() { Id = 3, Name = "Agnieszka", Surname = "Babacka", DateOfBirth = new DateTime(2000, 03, 11), RegistrationDate = DateTime.Now });
            modelBuilder.Entity<Client>().HasData(new Client() { Id = 4, Name = "Mateusz", Surname = "Dadacki", DateOfBirth = new DateTime(1986, 12, 31), RegistrationDate = DateTime.Now });
            modelBuilder.Entity<Client>().HasData(new Client() { Id = 5, Name = "Marcin", Surname = "Abacki", DateOfBirth = new DateTime(1999, 11, 01), RegistrationDate = DateTime.Now });
            modelBuilder.Entity<Client>().HasData(new Client() { Id = 6, Name = "Ewa", Surname = "Jakas", DateOfBirth = new DateTime(1978, 02, 15), RegistrationDate = DateTime.Now });

            //modelBuilder.Entity<Rental>(a=> {
            //    a.HasKey(b => b.Id);
            //    a.Property(b => b.Id).ValueGeneratedOnAdd();
            //});

            modelBuilder.Entity<Size>()
                .HasMany(a => a.Accessories)
                .WithOne(b => b.Size)
                .HasForeignKey(c => c.SizeId);
            modelBuilder.Entity<PetType>()
               .HasMany(a => a.Accessories)
               .WithOne(b => b.PetType)
               .HasForeignKey(c => c.PetTypeId);
            modelBuilder.Entity<Accessory>()
               .HasMany(a => a.Rentals)
               .WithOne(b => b.Accessory)
               .HasForeignKey(c => c.AccessoryId);
            modelBuilder.Entity<Client>()
               .HasMany(a => a.Rentals)
               .WithOne(b => b.Client)
               .HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 1, AccessoryName = "Kurtka Randig", OneDayRentalPrice = 10.00m, PetTypeId = 1, SizeId = 1 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 2, AccessoryName = "Kurtka Randig", OneDayRentalPrice = 10.00m, PetTypeId = 1, SizeId = 2 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 3, AccessoryName = "Kurtka Randig", OneDayRentalPrice = 10.00m, PetTypeId = 1, SizeId = 3 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 4, AccessoryName = "Kurtka Randig", OneDayRentalPrice = 10.00m, PetTypeId = 1, SizeId = 4 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 5, AccessoryName = "Kurtka Randig", OneDayRentalPrice = 10.00m, PetTypeId = 1, SizeId = 5 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 6, AccessoryName = "Kurtka Dotted", OneDayRentalPrice = 9.00m, PetTypeId = 2, SizeId = 1 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 7, AccessoryName = "Kurtka Dotted", OneDayRentalPrice = 9.00m, PetTypeId = 2, SizeId = 2 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 8, AccessoryName = "Kurtka Dotted", OneDayRentalPrice = 9.00m, PetTypeId = 2, SizeId = 3 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 9, AccessoryName = "Kurtka Dotted", OneDayRentalPrice = 9.00m, PetTypeId = 2, SizeId = 4 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 10, AccessoryName = "Kurtka Dotted", OneDayRentalPrice = 9.00m, PetTypeId = 2, SizeId = 5 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 11, AccessoryName = "Szelki Stripped", OneDayRentalPrice = 3.00m, PetTypeId = 1, SizeId = 4});
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 12, AccessoryName = "Szelki Stripped", OneDayRentalPrice = 3.00m, PetTypeId = 1, SizeId = 5});
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 13, AccessoryName = "Szelki Stripped", OneDayRentalPrice = 3.00m, PetTypeId = 2, SizeId = 4});
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 14, AccessoryName = "Szelki Stripped", OneDayRentalPrice = 3.00m, PetTypeId = 2, SizeId = 5});
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 15, AccessoryName = "Szelki Malutkie", OneDayRentalPrice = 5.00m, PetTypeId = 4, SizeId = 1 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 16, AccessoryName = "Szelki Malutkie", OneDayRentalPrice = 5.00m, PetTypeId = 4, SizeId = 2 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 17, AccessoryName = "Szelki Malutkie", OneDayRentalPrice = 5.00m, PetTypeId = 4, SizeId = 3 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 18, AccessoryName = "Szelki Malutkie", OneDayRentalPrice = 5.00m, PetTypeId = 5, SizeId = 1 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 19, AccessoryName = "Szelki Malutkie", OneDayRentalPrice = 5.00m, PetTypeId = 5, SizeId = 1 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 20, AccessoryName = "Szelki Malutkie", OneDayRentalPrice = 5.00m, PetTypeId = 5, SizeId = 1 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 21, AccessoryName = "Sweterek w Kwaiatki", OneDayRentalPrice = 4.00m, PetTypeId = 6, SizeId = 1 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 22, AccessoryName = "Sweterek w Kwaiatki", OneDayRentalPrice = 4.00m, PetTypeId = 6, SizeId = 2 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 23, AccessoryName = "Sweterek w Kwaiatki", OneDayRentalPrice = 4.00m, PetTypeId = 6, SizeId = 3 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 24, AccessoryName = "Sweterek w Kwaiatki", OneDayRentalPrice = 4.00m, PetTypeId = 6, SizeId = 5 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 25, AccessoryName = "Kurtka smiley", OneDayRentalPrice = 20.00m, PetTypeId = 7, SizeId = 1 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 26, AccessoryName = "Kurtka smiley", OneDayRentalPrice = 20.00m, PetTypeId = 7, SizeId = 2 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 27, AccessoryName = "Kurtka smiley", OneDayRentalPrice = 20.00m, PetTypeId = 7, SizeId = 3 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 28, AccessoryName = "Kurtka smiley", OneDayRentalPrice = 20.00m, PetTypeId = 7, SizeId = 4 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 29, AccessoryName = "Kurtka smiley", OneDayRentalPrice = 20.00m, PetTypeId = 7, SizeId = 5 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 30, AccessoryName = "Kurtka grey", OneDayRentalPrice = 17.00m, PetTypeId = 7, SizeId = 2 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 31, AccessoryName = "Kurtka grey", OneDayRentalPrice = 17.00m, PetTypeId = 7, SizeId = 3 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 32, AccessoryName = "Kurtka grey", OneDayRentalPrice = 17.00m, PetTypeId = 7, SizeId = 4 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 33, AccessoryName = "Szelki piggy", OneDayRentalPrice = 13.00m, PetTypeId = 8, SizeId = 1 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 34, AccessoryName = "Szelki piggy", OneDayRentalPrice = 13.00m, PetTypeId = 8, SizeId = 2 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 35, AccessoryName = "Kurtka warmy", OneDayRentalPrice = 10.00m, PetTypeId = 8, SizeId = 3 });
            modelBuilder.Entity<Accessory>().HasData(new Accessory() { Id = 36, AccessoryName = "Kurtka warmy", OneDayRentalPrice = 10.00m, PetTypeId = 8, SizeId = 5 });
        }
    }
}
