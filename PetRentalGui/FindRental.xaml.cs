using Microsoft.EntityFrameworkCore;
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
    /// Logika interakcji dla klasy FindRental.xaml
    /// </summary>
    public partial class FindRental : Page {
        public FindRental() {
            InitializeComponent();
        }

        private void SearchRental(object sender, EventArgs e) {

            string input = RentalValue.Text;
            //var valueRental = SearchRentalCategory.SelectedValue as ListBoxItem;
            //string tmp = valueRental.Content as string;

            if (input == "") {

                using (var ctx = new PetRentalContext()) {
                    var rentals = ctx.Rentals
                        .Include(a => a.Client)
                        .Include(b => b.Accessory)
                        .ToList();
                    foreach (var x in rentals) {
                        var row = new TableRow();
                        var c1 = TableCel(x.Id.ToString());
                        var c2 = TableCel(x.Client.Id.ToString());
                        var c3 = TableCel(x.Client.Name);
                        var c4 = TableCel(x.Client.Surname);
                        var c5 = TableCel(x.RentalDate.ToString());
                        var c6 = TableCel(x.ReturnDate.ToString());
                        var c7 = TableCel(x.Accessory.AccessoryName);
                        var c8 = TableCel(x.Accessory.Id.ToString());


                        row.Cells.Add(c1);
                        row.Cells.Add(c2);
                        row.Cells.Add(c3);
                        row.Cells.Add(c4);
                        row.Cells.Add(c5);
                        row.Cells.Add(c6);
                        row.Cells.Add(c7);
                        row.Cells.Add(c8);

                        TabelkaRental.Rows.Add(row);

                    }
                }
            } else {

                

                using (var ctx = new PetRentalContext()) {

                    var rentals = ctx.Rentals
                        .Include(a => a.Client)
                        .Include(b => b.Accessory)
                        .ToList();

                    int z;
                    DateTime y;
                    if (int.TryParse(input, out z)) {
                        rentals = rentals
                            .Where(a => a.ClientId == z).ToList();
                    } else if(DateTime.TryParse(input, out y)){

                        rentals = rentals
                            .Where(a => a.RentalDate.Date == y)
                            .ToList();
                    }

                    foreach (var x in rentals) {
                        var row = new TableRow();
                        var c1 = TableCel(x.Id.ToString());
                        var c2 = TableCel(x.Client.Id.ToString());
                        var c3 = TableCel(x.Client.Name);
                        var c4 = TableCel(x.Client.Surname);
                        var c5 = TableCel(x.RentalDate.ToString());
                        var c6 = TableCel(x.ReturnDate.ToString());
                        var c7 = TableCel(x.Accessory.AccessoryName);
                        var c8 = TableCel(x.Accessory.Id.ToString());


                        row.Cells.Add(c1);
                        row.Cells.Add(c2);
                        row.Cells.Add(c3);
                        row.Cells.Add(c4);
                        row.Cells.Add(c5);
                        row.Cells.Add(c6);
                        row.Cells.Add(c7);
                        row.Cells.Add(c8);

                        TabelkaRental.Rows.Add(row);

                    }

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
