using System;
using System.Linq;
using System.Windows.Controls;
using PetRentalCore;
using PetRentalCore.Model;

namespace PetRentalGui {
    /// <summary>
    /// Logika interakcji dla klasy AddClient.xaml
    /// </summary>
    public partial class AddClient : Page {
        public AddClient() {
            InitializeComponent();
        }

        private void AddNewClient(object sender, EventArgs e)
        {
            // dodawanie / C
            using var ctx = new PetRentalContext();
            
            var date = ClientDateOfBirth.SelectedDate;
            ctx.Clients.Add(new Client() {Name = ClientName.Text, Surname = ClientSurname.Text, DateOfBirth = DateTime.Parse(date.Value.ToString()), RegistrationDate = DateTime.Now });
            ctx.SaveChanges();
            

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
