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
        public DataTable leaderboardTable = new DataTable();

        public Menu()
        {
            InitializeComponent();
        }

        private void btnPradeti_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow main = new MainWindow(this);
            main.Show();
        }

        public DataTable addToDataTable(string data, int points)
        {
            bool increaseRemainingElements = false; // Ar didinti visus likusius elementus
            int index = 0;
            DataTable newDataTable = leaderboardTable;
            for (int i = 1; i <= newDataTable.Rows.Count; i++)
            {
                DataRow dr = newDataTable.Rows[i - 1];
                if (increaseRemainingElements)
                    dr["Vieta"] = i + 1;
                else
                {
                    if (Convert.ToInt32(dr["Taškai"]) <= points)
                    {
                        index = i;
                        dr["Vieta"] = i + 1;
                        increaseRemainingElements = true;
                    }
                }
            }
            if (index == 0)
                index = newDataTable.Rows.Count + 1;
            DataRow newRow = newDataTable.NewRow();
            newRow[0] = index;
            newRow[1] = data;
            newRow[2] = points;
            newDataTable.Rows.Add(newRow);
            return newDataTable;
        }

        private void sortLeaderBoard()
        {
            DataView dv = leaderboardTable.DefaultView;
            dv.Sort = "Vieta ASC";
            leaderboardTable = dv.ToTable();
            int lastIndex = leaderboardTable.Rows.Count;
            if (lastIndex > 10)
            {
                DataRow dr = leaderboardTable.Rows[lastIndex - 1];
                dr.Delete();
            }
        }

        private DataTable getDataTable(string path)
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

        private void writeToExcel(DataTable table)
        {
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = System.IO.Path.Combine(path, "Leaderboard.xlsx");
            FileInfo existingFile = new FileInfo(path);
            using (var pck = new OfficeOpenXml.ExcelPackage(existingFile))
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
            leaderboardTable = getDataTable(path);
        }

        private void btnHighScore_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard(leaderboardTable);
            sortLeaderBoard();
            leaderboard.ShowDialog();
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            writeToExcel(leaderboardTable);
        }
    }
}
