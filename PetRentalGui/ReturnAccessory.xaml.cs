using Microsoft.EntityFrameworkCore;
using PetRentalCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PetRentalGui {
    /// <summary>
    /// Logika interakcji dla klasy ReturnAccessory.xaml
    /// </summary>
    public partial class ReturnAccessory : Window {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ReturnAccessory() {
            InitializeComponent();
        }

        private void ReturnRentedAccessory(object sender, EventArgs e) {

            string input = ReturnInput.Text;
            int x;
            if (int.TryParse(input, out x)) {
                using (var ctx = new PetRentalContext()) {

                    var rentals = ctx.Rentals
                        .Where(b => b.ReturnDate == null)
                        .Where(c => c.AccessoryId == x).ToArray();

                    var accessories = ctx.Accessories
                        .Where(d => d.Id == x)
                        .ToList();

                    if (accessories.Count == 0) {
                        MessageBox.Show("Item does not exist in the database!");
                    } else if (rentals.Length == 0) {
                        MessageBox.Show("Selected item is not rented !");
                    } else {

                        rentals[0].ReturnDate = DateTime.Now;
                        int result = ctx.SaveChanges();
                        if (result == 1) {
                            MessageBox.Show("Item returned !");
                            
                        }


                        decimal amountToPay = accessories[0].OneDayRentalPrice;

                        int rentalDays = ((DateTime)rentals[0].ReturnDate.Value).Subtract(rentals[0].RentalDate).Days;
                        amountToPay += (accessories[0].OneDayRentalPrice * rentalDays);
                        AmountToPay.Text = amountToPay.ToString();
                    }


                }



            } else {
                MessageBox.Show("Incorrect id");
            }





        }
    }
}
