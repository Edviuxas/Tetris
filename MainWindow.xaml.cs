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

        public MainWindow(Menu menu)
        {
            Menu = menu;
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            int Eile = 1;
            int Stulpelis = 1;
            KeyDown += MainWindow_KeyDown;
            int x = 0;
            int y = 0;
            myBoard.myCnv = myCanvas;
            smallBoard.myCnv = myCanvas1;
            for (int i = 0; i < 200; i++) // nubraizom pagrindinius langelius REIKTU PERKELTI I BOARD KLASE?
            {
                Board.Langelis lang = new Board.Langelis();
                lang.myRect = new Rectangle();
                lang.myRect.Stroke = new SolidColorBrush(Colors.SaddleBrown);
                lang.myRect.StrokeThickness = 1;
                lang.myRect.Width = 30;
                lang.myRect.Height = 30;
                lang.myRect.Fill = new SolidColorBrush(Colors.Black);
                Canvas.SetLeft(lang.myRect, x);
                Canvas.SetTop(lang.myRect, y);
                myBoard.myCnv.Children.Add(lang.myRect);
                lang.Koord = new Point(Eile, Stulpelis);
                myBoard.VisiLangeliai.Add(lang);
                x += 30;
                Stulpelis += 1;
                if (x == 300)
                {
                    Eile += 1;
                    Stulpelis = 1;
                    y += 30;
                    x = 0;
                }
            }
            x = 360;
            y = 30;
            Eile = 1;
            Stulpelis = 1;
            for (int i = 0; i < 15; i++) // nubraizom salutinius langelius
            {
                Board.Langelis lang = new Board.Langelis();
                lang.myRect = new Rectangle();
                lang.myRect.Stroke = new SolidColorBrush(Colors.SaddleBrown);
                lang.myRect.StrokeThickness = 1;
                lang.myRect.Width = 30;
                lang.myRect.Height = 30;
                lang.myRect.Fill = new SolidColorBrush(Colors.Gainsboro);
                Canvas.SetLeft(lang.myRect, x);
                Canvas.SetTop(lang.myRect, y);
                smallBoard.myCnv.Children.Add(lang.myRect);
                lang.Koord = new Point(Eile, Stulpelis);
                smallBoard.VisiLangeliai.Add(lang);
                x += 30;
                Stulpelis += 1;
                if (x == 510)
                {
                    Eile += 1;
                    Stulpelis = 1;
                    y += 30;
                    x = 360;
                }
            }
            myBoard.GeneruotiDetales();
            BusimaDetale = myBoard.RandomDetale();
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
                        if (!myBoard.ArLieciaKaireSiena(d) && !myBoard.ArLieciaDetalesKaire(d))
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
                        if (myBoard.ArLieciaDetalesApacia(d))
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
                        if (!myBoard.ArLieciaDesineSiena(d) && !myBoard.ArLieciaDetalesDesine(d))
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
                        if (myBoard.ArLieciaDetalesApacia(d))
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
                        while (!myBoard.ArLieciaApatineSiena(d) && !myBoard.ArLieciaDetalesApacia(d))
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
            myBoard.GeneruotiDetales();
            d = BusimaDetale;
            BusimaDetale = myBoard.RandomDetale();
            foreach (var koord in d.LangeliuKoord)
            {
                myBoard.NuspalvintLangeli(Convert.ToInt32(koord.X), Convert.ToInt32(koord.Y), d.Spalva);
            }
            foreach (var koord in BusimaDetale.LangeliuKoord)
            {
                smallBoard.NuspalvintLangeliSmall(Convert.ToInt32(koord.X), Convert.ToInt32(koord.Y), BusimaDetale.Spalva);
            }
            if (!myBoard.ArLieciaDetalesApacia(d)) // tikrinam, ar tik atsiradus detalei ji nera ant kitos detales
            {
                t = new DispatcherTimer();
                t.Tick += t_Tick;
                t.Interval = new TimeSpan(0, 0, 0, 0, 250);
                t.Start();
            }
            else
            {
                t.Stop();
                GameOver GameOver = new GameOver(Menu, Taskai, this);
                GameOver.Show();
                //MessageBox.Show("Game over!");
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (myBoard.ArLieciaDetalesApacia(d) || myBoard.ArLieciaApatineSiena(d))
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
    }
}
