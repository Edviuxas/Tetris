using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;
using System.Media;

namespace Tetris
{
    class Board
    {

        public Board()
        {
            //GeneruotiDetales();
        }
        public Canvas myCnv;

        public struct Langelis
        {
            public Rectangle myRect;
            public Point Koord;
        }
        public List<Langelis> VisiLangeliai = new List<Langelis>();
        public List<Detale> VisosDetales = new List<Detale>();
        public List<Langelis> UzimtiLangeliai = new List<Langelis>();

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
            VisosDetales.Add(d1);
            VisosDetales.Add(d2);
            VisosDetales.Add(d3);
            VisosDetales.Add(d4);
            VisosDetales.Add(d5);
            VisosDetales.Add(d6);
            VisosDetales.Add(d7);
        }

        public Detale RandomDetale()
        {
            Random rnd = new Random();
            Detale d = new Detale();
            int indeksas = rnd.Next(VisosDetales.Count);
            d = VisosDetales[indeksas];
            return d;
        }

        public bool ArUzpildytaEile(int eile)
        {
            int Kiekis = 0;
            int indeksas = eile * 10 - 1;
            for (int a = indeksas - 9; a <= indeksas; a++)
            {
                SolidColorBrush brush = VisiLangeliai[a].myRect.Fill as SolidColorBrush;
                if (brush.Color != Colors.Black)
                    Kiekis += 1;
            }
            if (Kiekis == 10)
                return true;
            return false;
        }

        public void PanaikintiEile(int Eile)
        {
            MediaPlayer player = new MediaPlayer();
            string a = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string b = System.IO.Path.Combine(a, "sms-alert-3-daniel_simon.mp3");
            player.Open(new Uri(b));
            player.Play();
            for (int i = 0; i < UzimtiLangeliai.Count; i++)
            {
                if (Convert.ToInt32(UzimtiLangeliai[i].Koord.X) == Eile)
                {
                    NuspalvintLangeli(Convert.ToInt32(UzimtiLangeliai[i].Koord.X), Convert.ToInt32(UzimtiLangeliai[i].Koord.Y), Colors.Black);
                    UzimtiLangeliai.Remove(UzimtiLangeliai[i]);
                    i -= 1;
                }
            }
            UzimtiLangeliai = UzimtiLangeliai.OrderByDescending(p => p.Koord.X).ThenByDescending(p => p.Koord.Y).ToList(); // rikiavimas nuo apacios
            for (int i = 0; i < UzimtiLangeliai.Count; i++)
            {
                Langelis lang = UzimtiLangeliai[i];
                if (lang.Koord.X < Eile)
                {
                    SolidColorBrush brush = lang.myRect.Fill as SolidColorBrush;
                    NuspalvintLangeli(lang, Colors.Black);
                    NuspalvintLangeli(Convert.ToInt32(lang.Koord.X + 1), Convert.ToInt32(lang.Koord.Y), brush.Color);
                    int indeksas = Convert.ToInt32(lang.Koord.X * 10 - 10 + lang.Koord.Y - 1);
                    lang.Koord.X += 1;
                    UzimtiLangeliai[i] = VisiLangeliai[indeksas + 10];   
                }
            }
        }

        public void Isvalymas()
        {
            for (int i = 0; i < VisiLangeliai.Count; i++)
            {
                Langelis lang = VisiLangeliai[i];
                lang.myRect.Fill = new SolidColorBrush(Colors.Gainsboro);
                lang.myRect.Stroke = null;
                VisiLangeliai[i] = lang;
            }
        }

        #region ArLiecia

        public bool ArLieciaDetalesApacia(Detale d)
        {
            for (int i = 0; i < d.LangeliuKoord.Count; i++)
            {
                Point koord = d.LangeliuKoord[i];
                for (int a = 0; a < UzimtiLangeliai.Count; a++)
                {
                    if (koord.X + 1 == UzimtiLangeliai[a].Koord.X && koord.Y == UzimtiLangeliai[a].Koord.Y)
                        return true;
                }
            }
            return false;
        }

        public bool ArLieciaApatineSiena(Detale d)
        {
            for (int u = 0; u < d.LangeliuKoord.Count; u++)
                if (d.LangeliuKoord[u].X == 20)
                    return true;
            return false;
        }

        public bool ArLieciaDetalesKaire(Detale d)
        {
            for (int i = 0; i < d.LangeliuKoord.Count; i++)
            {
                Point koord = d.LangeliuKoord[i];
                for (int a = 0; a < UzimtiLangeliai.Count; a++)
                    if (koord.Y - 1 == UzimtiLangeliai[a].Koord.Y && koord.X == UzimtiLangeliai[a].Koord.X)
                        return true;
            }
            return false;
        }

        public bool ArLieciaKaireSiena(Detale d)
        {
            bool ArSiekia = false;
            for (int i = 0; i < d.LangeliuKoord.Count; i++)
            {
                Point koord = d.LangeliuKoord[i];
                if (koord.Y == 1)
                    ArSiekia = true;
            }
            return ArSiekia;
        }

        public bool ArLieciaDesineSiena(Detale d)
        {
            for (int i = 0; i < d.LangeliuKoord.Count; i++)
            {
                Point koord = d.LangeliuKoord[i];
                if (koord.Y == 10)
                    return true;
            }
            return false;
        }

        public bool ArLieciaDetalesDesine(Detale d)
        {
            for (int i = 0; i < d.LangeliuKoord.Count; i++)
            {
                Point koord = d.LangeliuKoord[i];
                for (int a = 0; a < UzimtiLangeliai.Count; a++)
                    if (koord.Y + 1 == UzimtiLangeliai[a].Koord.Y && koord.X == UzimtiLangeliai[a].Koord.X)
                        return true;
            }
            return false;
        }

        #endregion

        #region NuspalvintiLangeli

        public void NuspalvintLangeliSmall(int eile, int stulpelis, Color color)
        {
            int indeksas = (eile * 5) - (5 - stulpelis) + 2;
            Langelis lang = VisiLangeliai[indeksas];
            lang.myRect.Stroke = new SolidColorBrush(Colors.SaddleBrown);
            lang.myRect.StrokeThickness = 1;
            VisiLangeliai[indeksas].myRect.Fill = new SolidColorBrush(color);
            VisiLangeliai[indeksas] = lang;
        }

        public void NuspalvintLangeli(int eile, int stulpelis, Color color)
        {
            int indeksas = (eile * 10) - (10 - stulpelis) - 1;
            Langelis lang = VisiLangeliai[indeksas];
            VisiLangeliai[indeksas].myRect.Fill = new SolidColorBrush(color);
            VisiLangeliai[indeksas] = lang;
        }

        public void NuspalvintLangeli(Langelis lang, Color color)
        {
            lang.myRect.Fill = new SolidColorBrush(color);
        }

        #endregion
    }
}
