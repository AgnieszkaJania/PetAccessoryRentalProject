using System;
using Microsoft.EntityFrameworkCore;
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

            
        }


       private void SearchAccessory(object sender, EventArgs e) {

            var value = SearchCategory.SelectedValue as ListBoxItem;
            string tmp = value.Content as string;

            
                //throw new Exception();
                string input = Value.Text;
                using (var ctx = new PetRentalContext()) {


                var accessories =
                    ctx.Accessories
                    .Include(a=>a.PetType)
                    .Include(a=>a.Size)
                    .ToList();

                switch (tmp) {
                    case "Pet Type":
                    accessories = accessories
                        .Where(a=>a.PetType.PetTypeName == input)
                        .ToList();
                    break;
                    case "Name":
                    accessories = accessories
                        .Where(a => a.AccessoryName == input)
                        .ToList();
                    break;
                    case "Size":
                    accessories = accessories
                        .Where(a => a.Size.SizeName.ToString() == input)
                        .ToList();
                    break;
                }

                //var selectedAcc = accessories.Where(x => x.PetType.ToString() == input);
                foreach (var x in accessories) {
                        var row = new TableRow();
                        var c1 = TableCel(x.Id.ToString());
                        var c2 = TableCel(x.AccessoryName);
                        var c3 = TableCel(x.OneDayRentalPrice.ToString());
                        var c4 = TableCel(x.PetType.PetTypeName.Trim());
                        var c5 = TableCel(x.Size.SizeName.ToString());

                        row.Cells.Add(c1);
                        row.Cells.Add(c2);
                        row.Cells.Add(c3);
                        row.Cells.Add(c4);
                        row.Cells.Add(c5);

                        TabelkaAcc.Rows.Add(row);

                    }
                    //int id = 1;
                    //int
                    // Func<Accessory, bool> byName = accessory => accessory.Id == id;
                    // Func<Accessory, bool> bySize = accessory => accessory.Size == size;
                    // Func<Accessory, bool> byName = accessory => accessory.Id == id;
                    //ctx.Accessories.Where(byName)
                
                
            }
            
       }
        private TableCell TableCel(string content) {
            var cell = new TableCell();
            var paragraf = new Paragraph();
            paragraf.Inlines.Add(content);
            cell.Blocks.Add(paragraf);

            return cell;
        }
    }
}
