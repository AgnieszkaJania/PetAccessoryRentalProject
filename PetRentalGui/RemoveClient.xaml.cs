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

                using (var ctx = new PetRentalContext()) {

                    var clientToRemove = ctx.Clients.Where(x => x.Id == a).ToList();

                    if (clientToRemove.Count == 1) {

                        var clientRentals = ctx.Rentals.Where(x => x.ClientId == a).ToList();
                        if (clientRentals.Count == 0) {

                            ctx.Clients.Remove(clientToRemove[0]);
                            int result = ctx.SaveChanges();
                            if (result == 1) {
                                MessageBox.Show("Deleted !");
                            }
                            

                        } else {
                            MessageBox.Show("This client has already rented something !");
                        }

                    } else {

                        MessageBox.Show("Client not found !");
                    }


                }
                
               

            } else {

                MessageBox.Show("Incorrect client Id");
            }
            
        }
    }
}
