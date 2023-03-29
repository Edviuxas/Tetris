using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tetris
{
    public class LargeBoard
    {

        public LargeBoard()
        {
        }

        public Canvas myCnv;
        public List<Langelis> LargeBoardLangeliai = new List<Langelis>();
        public List<Langelis> UzimtiLangeliai = new List<Langelis>();

        public bool ArUzpildytaEile(int eile)
        {
            int Kiekis = 0;
            int indeksas = eile * 10 - 1;
            for (int a = indeksas - 9; a <= indeksas; a++)
            {
                SolidColorBrush brush = LargeBoardLangeliai[a].myRect.Fill as SolidColorBrush;
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
                    UzimtiLangeliai[i] = LargeBoardLangeliai[indeksas + 10];   
                }
            }
        }

        public void PiestiLenta()
        {
            int Eile = 1;
            int Stulpelis = 1;
            int x = 0;
            int y = 0;
            for (int i = 0; i < 200; i++)
            {
                Langelis lang = SukurtiNaujaLangeli();
                Canvas.SetLeft(lang.myRect, x);
                Canvas.SetTop(lang.myRect, y);
                myCnv.Children.Add(lang.myRect);
                lang.Koord = new Point(Eile, Stulpelis);
                LargeBoardLangeliai.Add(lang);
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
        }

        private static Langelis SukurtiNaujaLangeli()
        {
            Langelis lang = new Langelis();
            lang.myRect = new Rectangle();
            lang.myRect.Stroke = new SolidColorBrush(Colors.SaddleBrown);
            lang.myRect.StrokeThickness = 1;
            lang.myRect.Width = 30;
            lang.myRect.Height = 30;
            lang.myRect.Fill = new SolidColorBrush(Colors.Black);
            return lang;
        }

        #region NuspalvintiLangeli

        public void NuspalvintLangeli(int eile, int stulpelis, Color color)
        {
            int indeksas = (eile * 10) - (10 - stulpelis) - 1;
            Langelis lang = LargeBoardLangeliai[indeksas];
            LargeBoardLangeliai[indeksas].myRect.Fill = new SolidColorBrush(color);
            LargeBoardLangeliai[indeksas] = lang;
        }

        public void NuspalvintLangeli(Langelis lang, Color color)
        {
            lang.myRect.Fill = new SolidColorBrush(color);
        }

        #endregion
    }
}
