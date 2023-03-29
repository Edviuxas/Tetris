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
        LargeBoard myBoard = new LargeBoard();
        SmallBoard smallBoard = new SmallBoard();
        Piece d;
        Piece futurePiece;
        DispatcherTimer t;
        Menu menu;
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        int points = 0;
        bool isGameOver = false;
        public List<Piece> allPieces = new List<Piece>();

        public void generatePieces()
        {
            allPieces.Clear();
            Piece d1 = new Piece();
            d1.coordsOfSquare.Add(new Point(1, 4));
            d1.coordsOfSquare.Add(new Point(1, 5));
            d1.coordsOfSquare.Add(new Point(1, 6));
            d1.coordsOfSquare.Add(new Point(1, 7));
            d1.pieceNo = 1;
            d1.rotationAngle = 0;
            d1.color = Colors.Cyan;

            Piece d2 = new Piece();
            d2.coordsOfSquare.Add(new Point(2, 6));
            d2.coordsOfSquare.Add(new Point(1, 6));
            d2.coordsOfSquare.Add(new Point(1, 5));
            d2.coordsOfSquare.Add(new Point(1, 4));
            d2.pieceNo = 2;
            d2.rotationAngle = 0;
            d2.color = Colors.Blue;

            Piece d3 = new Piece();
            d3.coordsOfSquare.Add(new Point(2, 4));
            d3.coordsOfSquare.Add(new Point(1, 4));
            d3.coordsOfSquare.Add(new Point(1, 5));
            d3.coordsOfSquare.Add(new Point(1, 6));
            d3.pieceNo = 3;
            d3.rotationAngle = 0;
            d3.color = Colors.Orange;

            Piece d4 = new Piece();
            d4.coordsOfSquare.Add(new Point(2, 6));
            d4.coordsOfSquare.Add(new Point(2, 5));
            d4.coordsOfSquare.Add(new Point(1, 5));
            d4.coordsOfSquare.Add(new Point(1, 6));
            d4.pieceNo = 4;
            d4.rotationAngle = 0;
            d4.color = Colors.Yellow;

            Piece d5 = new Piece();
            d5.coordsOfSquare.Add(new Point(2, 6));
            d5.coordsOfSquare.Add(new Point(2, 5));
            d5.coordsOfSquare.Add(new Point(1, 5));
            d5.coordsOfSquare.Add(new Point(1, 4));
            d5.pieceNo = 5;
            d5.rotationAngle = 0;
            d5.color = Colors.Red;

            Piece d6 = new Piece();
            d6.coordsOfSquare.Add(new Point(2, 5));
            d6.coordsOfSquare.Add(new Point(1, 5));
            d6.coordsOfSquare.Add(new Point(1, 4));
            d6.coordsOfSquare.Add(new Point(1, 6));
            d6.pieceNo = 6;
            d6.rotationAngle = 0;
            d6.color = Colors.Purple;

            Piece d7 = new Piece();
            d7.coordsOfSquare.Add(new Point(2, 4));
            d7.coordsOfSquare.Add(new Point(2, 5));
            d7.coordsOfSquare.Add(new Point(1, 5));
            d7.coordsOfSquare.Add(new Point(1, 6));
            d7.pieceNo = 7;
            d7.rotationAngle = 0;
            d7.color = Colors.LimeGreen;

            allPieces.Add(d1);
            allPieces.Add(d2);
            allPieces.Add(d3);
            allPieces.Add(d4);
            allPieces.Add(d5);
            allPieces.Add(d6);
            allPieces.Add(d7);
        }

        public Piece randomPiece()
        {
            int index = rnd.Next(allPieces.Count);
            return allPieces[index]; ;
        }

        public MainWindow(Menu menu)
        {
            menu = menu;
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            KeyDown += MainWindow_KeyDown;
            myBoard.myCnv = myCanvas;
            smallBoard.myCnv = myCanvas1;
            myBoard.drawBoard();
            smallBoard.drawBoard();
            generatePieces();
            futurePiece = randomPiece();
            startAnimation();
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
                        keyUpHandling();
                        break;
                    case Key.Left:
                        keyLeftHandling();
                        break;
                    case Key.Right:
                        keyRightHandling();
                        break;
                    case Key.Space:
                        keySpaceHandling();
                        break;
                    default:
                        break;
                }
            }
        }

        private void keySpaceHandling()
        {
            for (int i = 0; i < d.coordsOfSquare.Count; i++)
            {
                Point coord = d.coordsOfSquare[i];
                myBoard.fillInSquare(Convert.ToInt32(coord.X), Convert.ToInt32(coord.Y), Colors.Black);
            }
            while (!d.isTouchingBottomWall(myBoard.occupiedSquares) && !d.isTouchingBottomOfPiece(myBoard.occupiedSquares))
            {
                for (int i = 0; i < d.coordsOfSquare.Count; i++)
                {
                    Point coord = d.coordsOfSquare[i];
                    coord.X += 1;
                    d.coordsOfSquare[i] = coord;
                }
            }
            for (int i = 0; i < d.coordsOfSquare.Count; i++)
            {
                int index = Convert.ToInt32(d.coordsOfSquare[i].X * 10 - (10 - d.coordsOfSquare[i].Y) - 1);
                Point coord = d.coordsOfSquare[i];
                myBoard.occupiedSquares.Add(myBoard.largeBoardSquares[index]);
                myBoard.fillInSquare(Convert.ToInt32(coord.X), Convert.ToInt32(coord.Y), d.color);
            }
            t.IsEnabled = false;
            isRowFilled();
            startAnimation();
        }

        private void keyRightHandling()
        {
            if (!d.isTouchingRightWall(myBoard.occupiedSquares) && !d.isTouchingRightOfPiece(myBoard.occupiedSquares))
            {
                for (int i = 0; i < d.coordsOfSquare.Count; i++)
                {
                    Point coord = d.coordsOfSquare[i];
                    myBoard.fillInSquare(Convert.ToInt32(coord.X), Convert.ToInt32(coord.Y), Colors.Black);
                    coord.Y += 1;
                    d.coordsOfSquare[i] = coord;
                }
                for (int i = 0; i < d.coordsOfSquare.Count; i++)
                {
                    Point coord = d.coordsOfSquare[i];
                    myBoard.fillInSquare(Convert.ToInt32(coord.X), Convert.ToInt32(coord.Y), d.color);
                    d.coordsOfSquare[i] = coord;
                }
            }
            if (d.isTouchingBottomOfPiece(myBoard.occupiedSquares))
            {
                t.IsEnabled = false;
                for (int i = 0; i < d.coordsOfSquare.Count; i++)
                {
                    int index = Convert.ToInt32(d.coordsOfSquare[i].X * 10 - (10 - d.coordsOfSquare[i].Y) - 1);
                    myBoard.occupiedSquares.Add(myBoard.largeBoardSquares[index]);
                }
                isRowFilled();
                startAnimation();
            }
        }

        private void keyLeftHandling()
        {
            if (!d.isTouchingLeftWall(myBoard.occupiedSquares) && !d.isTouchingLeftOfPiece(myBoard.occupiedSquares))
            {
                for (int i = 0; i < d.coordsOfSquare.Count; i++)
                {
                    Point coord = d.coordsOfSquare[i];
                    myBoard.fillInSquare(Convert.ToInt32(coord.X), Convert.ToInt32(coord.Y), Colors.Black);
                    coord.Y -= 1;
                    d.coordsOfSquare[i] = coord;
                }
                for (int i = 0; i < d.coordsOfSquare.Count; i++)
                {
                    Point coord = d.coordsOfSquare[i];
                    myBoard.fillInSquare(Convert.ToInt32(coord.X), Convert.ToInt32(coord.Y), d.color);
                    d.coordsOfSquare[i] = coord;
                }
            }
            if (d.isTouchingBottomOfPiece(myBoard.occupiedSquares))
            {
                t.IsEnabled = false;
                for (int i = 0; i < d.coordsOfSquare.Count; i++)
                {
                    int index = Convert.ToInt32(d.coordsOfSquare[i].X * 10 - (10 - d.coordsOfSquare[i].Y) - 1);
                    myBoard.occupiedSquares.Add(myBoard.largeBoardSquares[index]);
                }
                for (int i = 1; i <= 20; i++)
                {
                    if (myBoard.isRowFilled(i))
                    {
                        myBoard.removeRow(i);
                        points += 100;
                        blockpoints.Text = points.ToString();
                    }
                }
                startAnimation();
            }
        }

        private void keyUpHandling()
        {
            for (int c = 0; c < d.coordsOfSquare.Count; c++)
            {
                Point tmp = d.coordsOfSquare[c];
                myBoard.fillInSquare(Convert.ToInt32(tmp.X), Convert.ToInt32(tmp.Y), Colors.Black);
                d.coordsOfSquare[c] = tmp;
            }
            d.rotatePiece(myBoard);
            for (int c = 0; c < d.coordsOfSquare.Count; c++)
            {
                Point tmp = d.coordsOfSquare[c];
                myBoard.fillInSquare(Convert.ToInt32(tmp.X), Convert.ToInt32(tmp.Y), d.color);
            }
        }

        private void isRowFilled()
        {
            for (int i = 1; i <= 20; i++)
            {
                if (myBoard.isRowFilled(i))
                {
                    myBoard.removeRow(i);
                    points += 100;
                    blockpoints.Text = points.ToString();
                }
            }
        }

        private void startAnimation()
        {
            smallBoard.clearSmallBoard();
            generatePieces();
            d = futurePiece;
            futurePiece = randomPiece();

            drawCurrentPiece();
            drawNextPiece();

            if (!d.isTouchingBottomOfPiece(myBoard.occupiedSquares)) // tikrinam, ar tik atsiradus Piecei ji nera ant kitos Pieces
                startTimer();
            else
                endGame();
        }

        private void startTimer()
        {
            t = new DispatcherTimer();
            t.Tick += t_Tick;
            t.Interval = new TimeSpan(0, 0, 0, 0, 250);
            t.Start();
        }

        private void endGame()
        {
            t.Stop();
            isGameOver = true;
            GameOver gameOver = new GameOver(Menu, points, this);
            gameOver.Show();
        }

        private void drawCurrentPiece()
        {
            foreach (var coord in d.coordsOfSquare)
            {
                myBoard.fillInSquare(Convert.ToInt32(coord.X), Convert.ToInt32(coord.Y), d.color);
            }
        }

        private void drawNextPiece()
        {
            foreach (var coord in futurePiece.coordsOfSquare)
            {
                smallBoard.NuspalvintiLangeli(Convert.ToInt32(coord.X), Convert.ToInt32(coord.Y), futurePiece.color);
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (d.isTouchingBottomOfPiece(myBoard.occupiedSquares) || d.isTouchingBottomWall(myBoard.occupiedSquares))
            {
                t.IsEnabled = false;
                makePieceStatic();
                isRowFilled();
                startAnimation();
            }
            else
                movePiece();
        }

        private void makePieceStatic()
        {
            for (int i = 0; i < d.coordsOfSquare.Count; i++)
            {
                int index = Convert.ToInt32(d.coordsOfSquare[i].X * 10 - (10 - d.coordsOfSquare[i].Y) - 1);
                myBoard.occupiedSquares.Add(myBoard.largeBoardSquares[index]);
            }
        }

        private void movePiece()
        {
            fillInOldSquares();
            fillInNewSquares();
        }

        private void fillInNewSquares()
        {
            for (int c = 0; c < d.coordsOfSquare.Count; c++)
            {
                Point tmp = d.coordsOfSquare[c];
                myBoard.fillInSquare(Convert.ToInt32(tmp.X), Convert.ToInt32(tmp.Y), d.color);
            }
        }

        private void fillInOldSquares()
        {
            for (int c = 0; c < d.coordsOfSquare.Count; c++)
            {
                Point tmp = d.coordsOfSquare[c];
                myBoard.fillInSquare(Convert.ToInt32(tmp.X), Convert.ToInt32(tmp.Y), Colors.Black);
                tmp.X += 1;
                d.coordsOfSquare[c] = tmp;
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isGameOver)
                Application.Current.Shutdown();
        }
    }
}
