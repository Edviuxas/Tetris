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
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        int Taskai;
        Menu Menu;
        MainWindow Main;
        bool ArIsjungti = true;

        public GameOver(Menu menu, int Score, MainWindow main)
        {
            Main = main;
            Menu = menu;
            Taskai = Score;
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            blockTaskai.Text = Taskai.ToString();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            ArIsjungti = false;
            this.Close();
            Main.Close();
            Menu.Show();
        }

        private void btnIssaugoti_Click(object sender, RoutedEventArgs e)
        {
            ArIsjungti = false;
            Menu.TableLeaderboard = Menu.PridetiIDataTable(DateTime.Now.ToString("yyyy/MM/dd"), Taskai);
            this.Close();
            Main.Close();
            Menu.Show();
        }

        private void btnIsNaujo_Click(object sender, RoutedEventArgs e)
        {
            ArIsjungti = false;
            this.Close();
            Main.Close();
            MainWindow main = new MainWindow(Menu);
            main.Show();
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ArIsjungti)
                Application.Current.Shutdown();
        }
    }
}
