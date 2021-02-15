using Microsoft.EntityFrameworkCore;
using PetRentalCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PetRentalGui {
    /// <summary>
    /// Logika interakcji dla klasy FindAccessory.xaml
    /// </summary>
    public partial class FindAccessory : Page {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public FindAccessory() {
            InitializeComponent();


        }

        private void SearchAccessory(object sender, EventArgs e) {

            var value = SearchCategory.SelectedValue as ListBoxItem;
            string valueSearchCategory = value.Content as string;

            string input = Value.Text.Trim().ToLower();
            
            using (var ctx = new PetRentalContext()) {


                var accessories =
                    ctx.Accessories
                    .Include(a => a.PetType)
                    .Include(a => a.Size)
                    .Include(a=>a.Rentals)
                    .ToList();

                switch (valueSearchCategory) {
                    case "Pet Type":
                    accessories = accessories
                        .Where(a => a.PetType.PetTypeName.ToLower() == input)
                        .ToList();
                    break;
                    case "Name":
                    accessories = accessories
                        .Where(a => a.AccessoryName.ToLower().Contains(input))
                        .ToList();
                    break;
                    case "Rented accessories":
                    accessories = accessories
                        .Where(a => a.Rentals.Any(b => b.ReturnDate == null))
                        .ToList();
                    break;
                    case "Size":
                    accessories = accessories
                        .Where(a => a.Size.SizeName.ToString().ToLower() == input)
                        .ToList();
                    break;
                    case "All":
                    break;
                }

               
                if (accessories.Count == 0) {
                    MessageBox.Show("Accessory not found !");
                }

                foreach (var x in accessories) {
                    var row = new TableRow();
                    var c1 = TableCel(x.Id.ToString());
                    var c2 = TableCel(x.AccessoryName);
                    var c3 = TableCel(x.OneDayRentalPrice.ToString());
                    var c4 = TableCel(x.PetType.PetTypeName.Trim());
                    var c5 = TableCel(x.Size.SizeName.ToString());
                    var c6 = TableCel(x.isRented.ToString());

                    row.Cells.Add(c1);
                    row.Cells.Add(c2);
                    row.Cells.Add(c3);
                    row.Cells.Add(c4);
                    row.Cells.Add(c5);
                    row.Cells.Add(c6);

                    TabelkaAcc.Rows.Add(row);

                }
               


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
