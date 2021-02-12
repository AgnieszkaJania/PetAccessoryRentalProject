﻿using Microsoft.EntityFrameworkCore;
using PetRentalCore;
using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PetRentalGui {
    /// <summary>
    /// Logika interakcji dla klasy AddRental.xaml
    /// </summary>
    public partial class AddRental : Page {
        public AddRental() {
            InitializeComponent();
        }

        private void AddNewRental(object sender, EventArgs e) {
           
            string inputAccessory = AccessoryId.Text;
            string inputClient = ClientId.Text;
            int x;
            int y;
            if (int.TryParse(inputAccessory, out x) && int.TryParse(inputClient, out y)) {
                using var ctx = new PetRentalContext();

                 var rentals = ctx.Rentals
                    .Include(a => a.Accessory)
                    .ToList();
                var NotReturnedRentals = rentals
                    .Where(b => b.ReturnDate is null)
                    .Where(c => c.AccessoryId == x)
                    .ToList();
                var clients = ctx.Clients
                    .Where(z => z.Id == y)
                    .ToList();

                if (NotReturnedRentals.Count == 0 && clients.Count != 0) {
                    var tmp = new Rental() { ClientId = y, AccessoryId = x, RentalDate = DateTime.Now };
                    ctx.Rentals.Add(tmp);
                    ctx.SaveChanges();
                    Output.Text = "Rental added";
                } else {
                    Output.Text = "This accessory or client is unavailable !";
                }

               
            } else {
                Output.Text = "Incorrect id !";
            }
           
        }
    }
}
