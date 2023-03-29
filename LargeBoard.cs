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
        public List<Square> largeBoardSquares = new List<Square>();
        public List<Square> occupiedSquares = new List<Square>();

        public bool isRowFilled(int row)
        {
            int counter = 0;
            int index = row * 10 - 1;
            for (int a = index - 9; a <= index; a++)
            {
                SolidColorBrush brush = largeBoardSquares[a].myRect.Fill as SolidColorBrush;
                if (brush.Color != Colors.Black)
                    counter += 1;
            }
            if (counter == 10)
                return true;
            return false;
        }

        public void removeRow(int row)
        {
            MediaPlayer player = new MediaPlayer();
            string a = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string b = System.IO.Path.Combine(a, "sms-alert-3-daniel_simon.mp3");
            player.Open(new Uri(b));
            player.Play();
            for (int i = 0; i < occupiedSquares.Count; i++)
            {
                if (Convert.ToInt32(occupiedSquares[i].coord.X) == row)
                {
                    fillInSquare(Convert.ToInt32(occupiedSquares[i].coord.X), Convert.ToInt32(occupiedSquares[i].coord.Y), Colors.Black);
                    occupiedSquares.Remove(occupiedSquares[i]);
                    i -= 1;
                }
            }
            occupiedSquares = occupiedSquares.OrderByDescending(p => p.coord.X).ThenByDescending(p => p.coord.Y).ToList(); // rikiavimas nuo apacios
            for (int i = 0; i < occupiedSquares.Count; i++)
            {
                Square square = occupiedSquares[i];
                if (square.coord.X < row)
                {
                    SolidColorBrush brush = square.myRect.Fill as SolidColorBrush;
                    fillInSquare(square, Colors.Black);
                    fillInSquare(Convert.ToInt32(square.coord.X + 1), Convert.ToInt32(square.coord.Y), brush.Color);
                    int index = Convert.ToInt32(square.coord.X * 10 - 10 + square.coord.Y - 1);
                    occupiedSquares[i] = largeBoardSquares[index + 10];   
                }
            }
        }

        public void drawBoard()
        {
            int row = 1;
            int column = 1;
            int x = 0;
            int y = 0;
            for (int i = 0; i < 200; i++)
            {
                Square square = createNewSquare();
                Canvas.SetLeft(square.myRect, x);
                Canvas.SetTop(square.myRect, y);
                myCnv.Children.Add(square.myRect);
                square.coord = new Point(row, column);
                largeBoardSquares.Add(square);
                x += 30;
                column += 1;
                if (x == 300)
                {
                    row += 1;
                    column = 1;
                    y += 30;
                    x = 0;
                }
            }
        }

        private static Square createNewSquare()
        {
            Square square = new Square();
            square.myRect = new Rectangle();
            square.myRect.Stroke = new SolidColorBrush(Colors.SaddleBrown);
            square.myRect.StrokeThickness = 1;
            square.myRect.Width = 30;
            square.myRect.Height = 30;
            square.myRect.Fill = new SolidColorBrush(Colors.Black);
            return square;
        }

        #region fillInSquare

        public void fillInSquare(int row, int column, Color color)
        {
            int index = (row * 10) - (10 - column) - 1;
            Square square = largeBoardSquares[index];
            largeBoardSquares[index].myRect.Fill = new SolidColorBrush(color);
            largeBoardSquares[index] = square;
        }

        public void fillInSquare(Square square, Color color)
        {
            square.myRect.Fill = new SolidColorBrush(color);
        }

        #endregion
    }
}
