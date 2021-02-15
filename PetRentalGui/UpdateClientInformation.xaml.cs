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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PetRentalGui {
    /// <summary>
    /// Logika interakcji dla klasy UpdateClientInformation.xaml
    /// </summary>
    public partial class UpdateClientInformation : Page {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public UpdateClientInformation() {
            InitializeComponent();
        }
        private void ChangeValue(object sender, RoutedEventArgs e) {

            string inputClientId = ClientIdInput.Text.Trim();
            int id;
            var value = ValueToChange.SelectedValue as ListBoxItem;
            string selectedValue = value.Content as string;

            if (int.TryParse(inputClientId, out id)) {

                using(var ctx = new PetRentalContext()) {

                    var client = ctx.Clients
                       .Where(a => a.Id == id)
                       .ToList();
                    if (client.Count == 0) {
                        MessageBox.Show("Client not found !");

                    } else {
                        string inputData = InputNewClientValue.Text.Trim();
                        if (selectedValue == "Name") {
                            client[0].Name = inputData;
                            int result = ctx.SaveChanges();
                            if (result == 1) {
                                MessageBox.Show("Data changed !");
                            }
                            
                        }
                        if (selectedValue == "Surname") {
                            client[0].Surname = inputData;
                            int result = ctx.SaveChanges();
                            if (result == 1) {
                                MessageBox.Show("Data changed !");
                            }
                        }
                    }
                }

            } else {
                MessageBox.Show("Incorrect id !");
            }
            
           
        }
    }
}
