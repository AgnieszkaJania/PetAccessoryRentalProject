using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy AccesoryNotFound.xaml
    /// Klasa tworzy okno.
    /// Okno pojawia się, gdy nie znaleziono odpowiedniego akcesorium.
    /// </summary>
    public partial class AccesoryNotFound : Window {
        /// <summary>
        /// Konstruktor klasy AccessoryNotFound.
        /// </summary>
        public AccesoryNotFound() {
            InitializeComponent();
            
        }
        private  void HideWindow(object sender, RoutedEventArgs e ) {
            this.Close();
            
        }
    }
}
