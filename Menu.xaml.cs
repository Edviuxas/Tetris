using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using OfficeOpenXml;
using System.IO;
using System.Reflection;
using OfficeOpenXml.Style;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public DataTable TableLeaderboard = new DataTable();

        public Menu()
        {
            InitializeComponent();
        }

        private void btnPradeti_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow Main = new MainWindow(this);
            Main.Show();
        }

        public DataTable PridetiIDataTable(string Data, int Taskai)
        {
            bool arDidintiLikusiusElementus = false; // Ar didinti visus likusius elementus
            int KoksIndeksas = 0;
            DataTable Naujas = TableLeaderboard;
            for (int i = 1; i <= Naujas.Rows.Count; i++)
            {
                DataRow dr = Naujas.Rows[i - 1];
                if (arDidintiLikusiusElementus)
                    dr["Vieta"] = i + 1;
                else
                {
                    if (Convert.ToInt32(dr["Taškai"]) <= Taskai)
                    {
                        KoksIndeksas = i;
                        dr["Vieta"] = i + 1;
                        arDidintiLikusiusElementus = true;
                    }
                }
            }
            if (KoksIndeksas == 0)
                KoksIndeksas = Naujas.Rows.Count + 1;
            DataRow newRow = Naujas.NewRow();
            newRow[0] = KoksIndeksas;
            newRow[1] = Data;
            newRow[2] = Taskai;
            Naujas.Rows.Add(newRow);
            return Naujas;
        }

        private void SortLeaderBoard()
        {
            DataView dv = TableLeaderboard.DefaultView;
            dv.Sort = "Vieta ASC";
            TableLeaderboard = dv.ToTable();
            int PaskutinisIndeksas = TableLeaderboard.Rows.Count;
            if (PaskutinisIndeksas > 10)
            {
                DataRow dr = TableLeaderboard.Rows[PaskutinisIndeksas - 1];
                dr.Delete();
            }
        }

        private DataTable GautiDataTable(string path)
        {
            using (var pck = new ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets[1];
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    if (firstRowCell.Text == "Vieta" || firstRowCell.Text == "Taškai")
                        tbl.Columns.Add(firstRowCell.Text);
                    else
                        tbl.Columns.Add(firstRowCell.Text);
                }
                var startRow = 2;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        try
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                return tbl;
            }
        }

        private void SurasytiIExcel(DataTable table)
        {
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = System.IO.Path.Combine(path, "Leaderboard.xlsx");
            FileInfo ExistingFile = new FileInfo(path);
            using (var pck = new OfficeOpenXml.ExcelPackage(ExistingFile))
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets[1];
                ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Column(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Column(2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Column(3).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells["A1"].LoadFromDataTable(table, true);
                pck.Save();
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = System.IO.Path.Combine(path, "Leaderboard.xlsx");
            TableLeaderboard = GautiDataTable(path);
        }

        private void btnHighScore_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard Leaderboard = new Leaderboard(TableLeaderboard);
            SortLeaderBoard();
            Leaderboard.ShowDialog();
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SurasytiIExcel(TableLeaderboard);
        }
    }
}
