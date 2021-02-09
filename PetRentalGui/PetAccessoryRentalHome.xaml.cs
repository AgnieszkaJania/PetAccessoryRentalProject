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
using PetRentalGui;

namespace PetRentalGui {
    /// <summary>
    /// Logika interakcji dla klasy PetAccessoryRentalHome.xaml
    /// </summary>
    public partial class PetAccessoryRentalHome : Page {
        public PetAccessoryRentalHome() {
            InitializeComponent();
        }

        private void SearchClient(object o, RoutedEventArgs e) {

            FindClient findClient = new FindClient();
            this.NavigationService.Navigate(findClient);
            
        }
        private void SearchPetAccessory(object o, RoutedEventArgs e) {
            FindAccessory findAccessory = new FindAccessory();
            this.NavigationService.Navigate(findAccessory);
        }
        private void AddNewClient(object o, RoutedEventArgs e) {
            AddClient addClient = new AddClient();
            this.NavigationService.Navigate(addClient);
        }

        private void AddNewRental(object o, RoutedEventArgs e) {
            AddRental addRental = new AddRental();
            this.NavigationService.Navigate(addRental);
        }
        private void ExitApp(object o, RoutedEventArgs e) {
            Environment.Exit(0);
        }
    }


}
