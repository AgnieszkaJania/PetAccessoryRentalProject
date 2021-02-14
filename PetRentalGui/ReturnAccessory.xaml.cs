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
        public ReturnAccessory() {
            InitializeComponent();
        }

        private void ReturnRentedAccessory(object sender, EventArgs e) {

            string input = ReturnInput.Text;
            int x;
            if (int.TryParse(input, out x)) {
                using var ctx = new PetRentalContext();
                var rentals = ctx.Rentals
                    .Where(b => b.ReturnDate == null)
                    .Where(c => c.AccessoryId == x).ToArray();
                if (rentals.Length ==0) {
                    Output.Text = "Podana rzecz nie jest wypożyczona !";
                } else {

                    rentals[0].ReturnDate = DateTime.Now;
                    ctx.SaveChanges();
                }
                


            } else {
                Output.Text = "Niepoprawne id";
            }





        }
    }
}
