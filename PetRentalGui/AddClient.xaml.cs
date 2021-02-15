using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PetRentalCore;
using PetRentalCore.Model;

namespace PetRentalGui {
    /// <summary>
    /// Logika interakcji dla klasy AddClient.xaml
    /// Klasa tworzy nową stronę.
    /// Strona umożliwia dodanie nowego klienta do bazy.
    /// </summary>
    public partial class AddClient : Page {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public AddClient() {
            InitializeComponent();
        }

        private void AddNewClient(object sender, EventArgs e)
        {
            
            using (var ctx = new PetRentalContext()) {


                if (ClientName.Text.Length > 15 || ClientSurname.Text.Length > 20) {
                    MessageBox.Show("Name or Surname is too long !");
                } else {
                    var date = ClientDateOfBirth.SelectedDate;
                    var newClient = new Client() {
                        Name = ClientName.Text.Trim(),
                        Surname = ClientSurname.Text.Trim(),
                        DateOfBirth = DateTime.Parse(date.Value.ToString()),
                        RegistrationDate = DateTime.Now
                    };
                    ctx.Clients.Add(newClient);
                    int result = ctx.SaveChanges();
                    if (result == 1) {
                        MessageBox.Show("Client added !");
                    }
                }

            }


            // read

//            using (var ctx = new PetRentalContext())
//            {
//                var res  = ctx.Clients.ToList();
//                var client = ctx.Clients.Where(x => x.Id == 1).Single();

//                client.Name = "dsds";
//                ctx.SaveChanges();

//                ctx.Clients.Remove(client);

//               // ctx.Rentals.R
//                ctx.SaveChanges();
////
//              //  var acc = ctx.Accessories.Where().Single();
//             //   ctx.Rentals.Add(new Rental() {Accessory = acc ,Client = client ,})
//                //client.Rentals.
//            }


        }
    }
}
