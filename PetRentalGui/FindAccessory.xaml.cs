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
using PetRentalCore;
using PetRentalCore.Model;

namespace PetRentalGui {
    /// <summary>
    /// Logika interakcji dla klasy FindAccessory.xaml
    /// </summary>
    public partial class FindAccessory : Page {
        public FindAccessory()
        {
            InitializeComponent();

            using (var ctx = new PetRentalContext())
            {
                //int id = 1;
                //int
                // Func<Accessory, bool> byName = accessory => accessory.Id == id;
                // Func<Accessory, bool> bySize = accessory => accessory.Size == size;
                // Func<Accessory, bool> byName = accessory => accessory.Id == id;
                //ctx.Accessories.Where(byName)
            }
        }
    }
}
