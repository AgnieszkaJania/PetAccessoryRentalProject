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
    /// Logika interakcji dla klasy RemoveClient.xaml
    /// </summary>
    public partial class RemoveClient : Window {
        public RemoveClient() {
            InitializeComponent();
        }

        private void RemoveSelClient(object sender, EventArgs e) {

            var clientId = ClientToRemId.Text;
            int a;
            
            
            if (int.TryParse(clientId, out a)) {

                using var ctx = new PetRentalContext();
                var clientToRemove = ctx.Clients.Where(x => x.Id == a).Single();
                if (clientToRemove != null ) {
                    var clientRentals = ctx.Rentals.Where(x => x.ClientId == a).ToList();
                    if (clientRentals.Count == 0) {
                        ctx.Clients.Remove(clientToRemove);
                        ctx.SaveChanges();
                        Response.Text = "Deleted !";

                    } else {
                        Response.Text = "This client has already rented something !";
                    }
                    
                } else {
                    
                    Response.Text = "Client not found !";
                }
               

            } else {

                Response.Text = "Incorrect client Id";
            }
            
        }
    }
}
