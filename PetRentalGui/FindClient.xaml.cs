using PetRentalCore;
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

namespace PetRentalGui {
    /// <summary>
    /// Logika interakcji dla klasy FindClient.xaml
    /// </summary>
    public partial class FindClient : Page {
        public FindClient() {
            InitializeComponent();
        }

        private void SearchClient(object sender, EventArgs e) {

            if (ClientIdOrName.Text == "") {

                using (var ctx = new PetRentalContext()) {
                    var res = ctx.Clients.ToList();
                    foreach (var x in res) {
                        var row = new TableRow();
                        var c1 = TableCel(x.Id.ToString());
                        var c2 = TableCel(x.Name);
                        var c3 = TableCel(x.Surname);
                        var c4 = TableCel(x.DateBirth);
                        var c5 = TableCel(x.DateRegistration);

                        row.Cells.Add(c1);
                        row.Cells.Add(c2);
                        row.Cells.Add(c3);
                        row.Cells.Add(c4);
                        row.Cells.Add(c5);

                        Tabelka.Rows.Add(row);

                    }
                }
            } else {
                string input = ClientIdOrName.Text;
                int a;
                if (int.TryParse(input, out a)) {

                    using (var ctx = new PetRentalContext()) {
                        var res = ctx.Clients.Where(x => x.Id == a).ToList();
                        foreach (var x in res) {
                            var row = new TableRow();
                            var c1 = TableCel(x.Id.ToString());
                            var c2 = TableCel(x.Name);
                            var c3 = TableCel(x.Surname);
                            var c4 = TableCel(x.DateBirth);
                            var c5 = TableCel(x.DateRegistration);

                            row.Cells.Add(c1);
                            row.Cells.Add(c2);
                            row.Cells.Add(c3);
                            row.Cells.Add(c4);
                            row.Cells.Add(c5);

                            Tabelka.Rows.Add(row);

                        }
                    }
                } else {
                    using (var ctx = new PetRentalContext()) {
                        var res = ctx.Clients.Where(x => x.Surname == input).ToList();
                        foreach (var x in res) {
                            var row = new TableRow();
                            var c1 = TableCel(x.Id.ToString());
                            var c2 = TableCel(x.Name);
                            var c3 = TableCel(x.Surname);
                            var c4 = TableCel(x.DateBirth);
                            var c5 = TableCel(x.DateRegistration);

                            row.Cells.Add(c1);
                            row.Cells.Add(c2);
                            row.Cells.Add(c3);
                            row.Cells.Add(c4);
                            row.Cells.Add(c5);

                            Tabelka.Rows.Add(row);

                        }
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
