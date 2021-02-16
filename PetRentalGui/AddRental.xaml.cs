using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public AddRental() {
            InitializeComponent();
        }

        private void AddNewRental(object sender, EventArgs e) {
           
            string inputAccessory = AccessoryId.Text;
            string inputClient = ClientId.Text;
            int x;
            int y;
            if (int.TryParse(inputAccessory, out x) && int.TryParse(inputClient, out y)) {
                using (var ctx = new PetRentalContext()) {

                    var rentals = ctx.Rentals
                        .Include(a => a.Accessory)
                        .ToList();
                    var acc = ctx.Accessories
                        .Where(p => p.Id == x)
                        .ToList();
                    var NotReturnedRentals = rentals
                        .Where(b => b.ReturnDate is null)
                        .Where(c => c.AccessoryId == x)
                        .ToList();
                    var clients = ctx.Clients
                        .Where(z => z.Id == y)
                        .ToList();


                    if (NotReturnedRentals.Count == 0) {

                        if (clients.Count == 1) {

                            if (acc.Count == 0) {
                                MessageBox.Show("This item does not exist in the database !");
                            } else {

                                Client client = clients[0];
                                Accessory accessory = acc[0];
                                 
                                var newRental = new Rental() { Client = client, Accessory = accessory, RentalDate = DateTime.Now };
                                ctx.Rentals.Add(newRental);
                                int result = ctx.SaveChanges();
                                if (result == 1) {
                                    MessageBox.Show("Rental added !");
                                }

                            }

                        } else {
                            MessageBox.Show("Client not found !");
                        }

                    } else {
                        MessageBox.Show("This accessory is rented now !");
                    }



                }



            } else {
                MessageBox.Show("Incorrect id !");
            }
           
        }
    }
}
