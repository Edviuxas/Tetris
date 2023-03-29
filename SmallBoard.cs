using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tetris
{
    class SmallBoard
    {
        public Canvas myCnv;
        private List<Langelis> SmallBoardLangeliai = new List<Langelis>();
        public void PiestiLenta()
        {
            int x = 360;
            int y = 30;
            int Eile = 1;
            int Stulpelis = 1;
            for (int i = 0; i < 15; i++) // nubraizom salutinius langelius
            {
                Langelis lang = SukurtiNaujaLangeli();
                Canvas.SetLeft(lang.myRect, x);
                Canvas.SetTop(lang.myRect, y);
                myCnv.Children.Add(lang.myRect);
                lang.Koord = new Point(Eile, Stulpelis);
                SmallBoardLangeliai.Add(lang);
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
        }

        private static Langelis SukurtiNaujaLangeli()
        {
            Langelis lang = new Langelis();
            lang.myRect = new Rectangle();
            lang.myRect.StrokeThickness = 1;
            lang.myRect.Width = 30;
            lang.myRect.Height = 30;
            lang.myRect.Fill = new SolidColorBrush(Colors.Gainsboro);
            return lang;
        }

        public void NuspalvintiLangeli(int eile, int stulpelis, Color color)
        {
            int indeksas = (eile * 5) - (5 - stulpelis) + 2;
            Langelis lang = SmallBoardLangeliai[indeksas];
            lang.myRect.Stroke = new SolidColorBrush(Colors.SaddleBrown);
            lang.myRect.StrokeThickness = 1;
            SmallBoardLangeliai[indeksas].myRect.Fill = new SolidColorBrush(color);
            SmallBoardLangeliai[indeksas] = lang;
        }

        public void Isvalymas()
        {
            for (int i = 0; i < SmallBoardLangeliai.Count; i++)
            {
                Langelis lang = SmallBoardLangeliai[i];
                lang.myRect.Fill = new SolidColorBrush(Colors.Gainsboro);
                lang.myRect.Stroke = null;
                SmallBoardLangeliai[i] = lang;
            }
        }
    }
}
