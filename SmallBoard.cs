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
        private List<Square> smallBoardSquares = new List<Square>();
        public void drawBoard()
        {
            int x = 360;
            int y = 30;
            int row = 1;
            int column = 1;
            for (int i = 0; i < 15; i++) // nubraizom salutinius langelius
            {
                Square square = createNewSquare();
                Canvas.SetLeft(square.myRect, x);
                Canvas.SetTop(square.myRect, y);
                myCnv.Children.Add(square.myRect);
                square.coord = new Point(row, column);
                smallBoardSquares.Add(square);
                x += 30;
                column += 1;
                if (x == 510)
                {
                    row += 1;
                    column = 1;
                    y += 30;
                    x = 360;
                }
            }
        }

        private static Square createNewSquare()
        {
            Square square = new Square();
            square.myRect = new Rectangle();
            square.myRect.StrokeThickness = 1;
            square.myRect.Width = 30;
            square.myRect.Height = 30;
            square.myRect.Fill = new SolidColorBrush(Colors.Gainsboro);
            return square;
        }

        public void fillInSquare(int row, int column, Color color)
        {
            int index = (row * 5) - (5 - column) + 2;
            Square square = smallBoardSquares[index];
            square.myRect.Stroke = new SolidColorBrush(Colors.SaddleBrown);
            square.myRect.StrokeThickness = 1;
            smallBoardSquares[index].myRect.Fill = new SolidColorBrush(color);
            smallBoardSquares[index] = square;
        }

        public void clearSmallBoard()
        {
            for (int i = 0; i < smallBoardSquares.Count; i++)
            {
                Square square = smallBoardSquares[i];
                square.myRect.Fill = new SolidColorBrush(Colors.Gainsboro);
                square.myRect.Stroke = null;
                smallBoardSquares[i] = square;
            }
        }
    }
}
