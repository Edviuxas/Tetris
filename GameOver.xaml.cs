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
        int points;
        Menu menu;
        MainWindow main;
        bool shouldTurnOff = true;

        public GameOver(Menu menu, int score, MainWindow main)
        {
            this.main = main;
            this.menu = menu;
            points = score;
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            blockTaskai.Text = points.ToString();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            shouldTurnOff = false;
            this.Close();
            main.Close();
            menu.Show();
        }

        private void btnIssaugoti_Click(object sender, RoutedEventArgs e)
        {
            shouldTurnOff = false;
            menu.leaderboardTable = menu.addToDataTable(DateTime.Now.ToString("yyyy/MM/dd"), points);
            this.Close();
            main.Close();
            menu.Show();
        }

        private void btnIsNaujo_Click(object sender, RoutedEventArgs e)
        {
            shouldTurnOff = false;
            this.Close();
            main.Close();
            MainWindow main = new MainWindow(Menu);
            main.Show();
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (shouldTurnOff)
                Application.Current.Shutdown();
        }
    }
}
