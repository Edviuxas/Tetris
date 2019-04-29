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
using System.Windows.Threading;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Board myBoard = new Board();
        Board smallBoard = new Board();
        Detale d;
        Detale BusimaDetale;
        DispatcherTimer t;
        Menu Menu;
        int Taskai = 0;
        bool arGameOver = false;
        public List<Detale> VisosDetales = new List<Detale>();

        public void GeneruotiDetales()
        {
            VisosDetales.Clear();
            Detale d1 = new Detale();
            d1.LangeliuKoord.Add(new Point(1, 4));
            d1.LangeliuKoord.Add(new Point(1, 5));
            d1.LangeliuKoord.Add(new Point(1, 6));
            d1.LangeliuKoord.Add(new Point(1, 7));
            d1.DetalesNr = 1;
            d1.PasukimoKampas = 0;
            d1.Spalva = Colors.Cyan;
            Detale d2 = new Detale();
            d2.LangeliuKoord.Add(new Point(2, 6));
            d2.LangeliuKoord.Add(new Point(1, 6));
            d2.LangeliuKoord.Add(new Point(1, 5));
            d2.LangeliuKoord.Add(new Point(1, 4));
            d2.DetalesNr = 2;
            d2.PasukimoKampas = 0;
            d2.Spalva = Colors.Blue;
            Detale d3 = new Detale();
            d3.LangeliuKoord.Add(new Point(2, 4));
            d3.LangeliuKoord.Add(new Point(1, 4));
            d3.LangeliuKoord.Add(new Point(1, 5));
            d3.LangeliuKoord.Add(new Point(1, 6));
            d3.DetalesNr = 3;
            d3.PasukimoKampas = 0;
            d3.Spalva = Colors.Orange;
            Detale d4 = new Detale();
            d4.LangeliuKoord.Add(new Point(2, 6));
            d4.LangeliuKoord.Add(new Point(2, 5));
            d4.LangeliuKoord.Add(new Point(1, 5));
            d4.LangeliuKoord.Add(new Point(1, 6));
            d4.DetalesNr = 4;
            d4.PasukimoKampas = 0;
            d4.Spalva = Colors.Yellow;
            Detale d5 = new Detale();
            d5.LangeliuKoord.Add(new Point(2, 6));
            d5.LangeliuKoord.Add(new Point(2, 5));
            d5.LangeliuKoord.Add(new Point(1, 5));
            d5.LangeliuKoord.Add(new Point(1, 4));
            d5.DetalesNr = 5;
            d5.PasukimoKampas = 0;
            d5.Spalva = Colors.Red;
            Detale d6 = new Detale();
            d6.LangeliuKoord.Add(new Point(2, 5));
            d6.LangeliuKoord.Add(new Point(1, 5));
            d6.LangeliuKoord.Add(new Point(1, 4));
            d6.LangeliuKoord.Add(new Point(1, 6));
            d6.DetalesNr = 6;
            d6.PasukimoKampas = 0;
            d6.Spalva = Colors.Purple;
            Detale d7 = new Detale();
            d7.LangeliuKoord.Add(new Point(2, 4));
            d7.LangeliuKoord.Add(new Point(2, 5));
            d7.LangeliuKoord.Add(new Point(1, 5));
            d7.LangeliuKoord.Add(new Point(1, 6));
            d7.DetalesNr = 7;
            d7.PasukimoKampas = 0;
            d7.Spalva = Colors.LimeGreen;
            Detale d8 = new Detale();
            d8.LangeliuKoord.Add(new Point(1, 5));
            d8.LangeliuKoord.Add(new Point(1, 4));
            d8.LangeliuKoord.Add(new Point(1, 6));
            d8.LangeliuKoord.Add(new Point(2, 4));
            d8.LangeliuKoord.Add(new Point(2, 6));
            d8.DetalesNr = 8;
            d8.PasukimoKampas = 0;
            d8.Spalva = Colors.DarkKhaki;
            VisosDetales.Add(d1);
            VisosDetales.Add(d2);
            VisosDetales.Add(d3);
            VisosDetales.Add(d4);
            VisosDetales.Add(d5);
            VisosDetales.Add(d6);
            VisosDetales.Add(d7);
            VisosDetales.Add(d8);
        }

        public Detale RandomDetale()
        {
            Random rnd = new Random();
            Detale d = new Detale();
            int indeksas = rnd.Next(VisosDetales.Count);
            d = VisosDetales[indeksas];
            return d;
        }

        public MainWindow(Menu menu)
        {
            Menu = menu;
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            KeyDown += MainWindow_KeyDown;
            myBoard.myCnv = myCanvas;
            smallBoard.myCnv = myCanvas1;
            myBoard.PiestiPagrindineLenta();
            smallBoard.PiestiSalutineLenta();
            GeneruotiDetales();
            BusimaDetale = RandomDetale();
            StartAnimation();
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (t.IsEnabled)
            {
                switch (e.Key)
                {
                    case Key.Down:
                        break;
                    case Key.Up:
                        for (int c = 0; c < d.LangeliuKoord.Count; c++)
                        {
                            Point tmp = d.LangeliuKoord[c];
                            myBoard.NuspalvintLangeli(Convert.ToInt32(tmp.X), Convert.ToInt32(tmp.Y), Colors.Black);
                            d.LangeliuKoord[c] = tmp;
                        }
                        d.DetalesPasukimas(myBoard);
                        for (int c = 0; c < d.LangeliuKoord.Count; c++)
                        {
                            Point tmp = d.LangeliuKoord[c];
                            myBoard.NuspalvintLangeli(Convert.ToInt32(tmp.X), Convert.ToInt32(tmp.Y), d.Spalva);
                        }
                        break;
                    case Key.Left:
                        if (!d.ArLieciaKaireSiena(myBoard.UzimtiLangeliai) && !d.ArLieciaDetalesKaire(myBoard.UzimtiLangeliai))
                        {
                            for (int i = 0; i < d.LangeliuKoord.Count; i++)
                            {
                                Point koord = d.LangeliuKoord[i];
                                myBoard.NuspalvintLangeli(Convert.ToInt32(koord.X), Convert.ToInt32(koord.Y), Colors.Black);
                                koord.Y -= 1;
                                d.LangeliuKoord[i] = koord;
                            }
                            for (int i = 0; i < d.LangeliuKoord.Count; i++)
                            {
                                Point koord = d.LangeliuKoord[i];
                                myBoard.NuspalvintLangeli(Convert.ToInt32(koord.X), Convert.ToInt32(koord.Y), d.Spalva);
                                d.LangeliuKoord[i] = koord;
                            }
                        }
                        if (d.ArLieciaDetalesApacia(myBoard.UzimtiLangeliai))
                        {
                            t.IsEnabled = false;
                            for (int i = 0; i < d.LangeliuKoord.Count; i++)
                            {
                                int indeksas = Convert.ToInt32(d.LangeliuKoord[i].X * 10 - (10 - d.LangeliuKoord[i].Y) - 1);
                                myBoard.UzimtiLangeliai.Add(myBoard.VisiLangeliai[indeksas]);
                            }
                            for (int i = 1; i <= 20; i++)
                            {
                                if (myBoard.ArUzpildytaEile(i))
                                {
                                    myBoard.PanaikintiEile(i);
                                    Taskai += 100;
                                    blockTaskai.Text = Taskai.ToString();
                                }
                            }
                            StartAnimation();
                        }
                        break;
                    case Key.Right:
                        if (!d.ArLieciaDesineSiena(myBoard.UzimtiLangeliai) && !d.ArLieciaDetalesDesine(myBoard.UzimtiLangeliai))
                        {
                            for (int i = 0; i < d.LangeliuKoord.Count; i++)
                            {
                                Point koord = d.LangeliuKoord[i];
                                myBoard.NuspalvintLangeli(Convert.ToInt32(koord.X), Convert.ToInt32(koord.Y), Colors.Black);
                                koord.Y += 1;
                                d.LangeliuKoord[i] = koord;
                            }
                            for (int i = 0; i < d.LangeliuKoord.Count; i++)
                            {
                                Point koord = d.LangeliuKoord[i];
                                myBoard.NuspalvintLangeli(Convert.ToInt32(koord.X), Convert.ToInt32(koord.Y), d.Spalva);
                                d.LangeliuKoord[i] = koord;
                            }
                        }
                        if (d.ArLieciaDetalesApacia(myBoard.UzimtiLangeliai))
                        {
                            t.IsEnabled = false;
                            for (int i = 0; i < d.LangeliuKoord.Count; i++)
                            {
                                int indeksas = Convert.ToInt32(d.LangeliuKoord[i].X * 10 - (10 - d.LangeliuKoord[i].Y) - 1);
                                myBoard.UzimtiLangeliai.Add(myBoard.VisiLangeliai[indeksas]);
                            }
                            ArUzpildytaEile();
                            StartAnimation();
                        }
                        break;
                    case Key.Space:
                        for (int i = 0; i < d.LangeliuKoord.Count; i++)
                        {
                            Point Koord = d.LangeliuKoord[i];
                            myBoard.NuspalvintLangeli(Convert.ToInt32(Koord.X), Convert.ToInt32(Koord.Y), Colors.Black);
                        }
                        while (!d.ArLieciaApatineSiena(myBoard.UzimtiLangeliai) && !d.ArLieciaDetalesApacia(myBoard.UzimtiLangeliai))
                        {
                            for (int i = 0; i < d.LangeliuKoord.Count; i++)
                            {
                                Point koord = d.LangeliuKoord[i];
                                koord.X += 1;
                                d.LangeliuKoord[i] = koord;
                            }
                        }
                        for (int i = 0; i < d.LangeliuKoord.Count; i++)
                        {
                            int indeksas = Convert.ToInt32(d.LangeliuKoord[i].X * 10 - (10 - d.LangeliuKoord[i].Y) - 1);
                            Point Koord = d.LangeliuKoord[i];
                            myBoard.UzimtiLangeliai.Add(myBoard.VisiLangeliai[indeksas]);
                            myBoard.NuspalvintLangeli(Convert.ToInt32(Koord.X), Convert.ToInt32(Koord.Y), d.Spalva);
                        }
                        t.IsEnabled = false;
                        ArUzpildytaEile();
                        StartAnimation();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ArUzpildytaEile()
        {
            for (int i = 1; i <= 20; i++)
            {
                if (myBoard.ArUzpildytaEile(i))
                {
                    myBoard.PanaikintiEile(i);
                    Taskai += 100;
                    blockTaskai.Text = Taskai.ToString();
                }
            }
        }

        private void StartAnimation()
        {
            smallBoard.Isvalymas();
            GeneruotiDetales();
            d = BusimaDetale;
            BusimaDetale = RandomDetale();
            foreach (var koord in d.LangeliuKoord)
            {
                myBoard.NuspalvintLangeli(Convert.ToInt32(koord.X), Convert.ToInt32(koord.Y), d.Spalva);
            }
            foreach (var koord in BusimaDetale.LangeliuKoord)
            {
                smallBoard.NuspalvintLangeliSmall(Convert.ToInt32(koord.X), Convert.ToInt32(koord.Y), BusimaDetale.Spalva);
            }
            if (!d.ArLieciaDetalesApacia(myBoard.UzimtiLangeliai)) // tikrinam, ar tik atsiradus detalei ji nera ant kitos detales
            {
                t = new DispatcherTimer();
                t.Tick += t_Tick;
                t.Interval = new TimeSpan(0, 0, 0, 0, 250);
                t.Start();
            }
            else
            {
                t.Stop();
                arGameOver = true;
                GameOver GameOver = new GameOver(Menu, Taskai, this);
                GameOver.Show();
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (d.ArLieciaDetalesApacia(myBoard.UzimtiLangeliai) || d.ArLieciaApatineSiena(myBoard.UzimtiLangeliai))
            {
                t.IsEnabled = false;
                for (int i = 0; i < d.LangeliuKoord.Count; i++)
                {
                    int indeksas = Convert.ToInt32(d.LangeliuKoord[i].X * 10 - (10 - d.LangeliuKoord[i].Y) - 1);
                    myBoard.UzimtiLangeliai.Add(myBoard.VisiLangeliai[indeksas]);
                }
                ArUzpildytaEile();
                StartAnimation();
            }
            else
            {
                for (int c = 0; c < d.LangeliuKoord.Count; c++)
                {
                    Point tmp = d.LangeliuKoord[c];
                    myBoard.NuspalvintLangeli(Convert.ToInt32(tmp.X), Convert.ToInt32(tmp.Y), Colors.Black);
                    tmp.X += 1;
                    d.LangeliuKoord[c] = tmp;
                }
                for (int c = 0; c < d.LangeliuKoord.Count; c++)
                {
                    Point tmp = d.LangeliuKoord[c];
                    myBoard.NuspalvintLangeli(Convert.ToInt32(tmp.X), Convert.ToInt32(tmp.Y), d.Spalva);
                }
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!arGameOver)
                Application.Current.Shutdown();
        }
    }
}
