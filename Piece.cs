using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Tetris
{
    public class Piece
    {
        public Piece()
        {

        }
        public List<Point> coordsOfSquare = new List<Point>();
        public int pieceNo; // 1 - pailga; 2 - 1,3; 3 - 3,1; 4 - kvadratas; 5 - zigzag; 6 - T; 7 - zigzag
        public int rotationAngle; // kokiu kampu dabar yra pasisukus detale
        public Color color;
        private readonly List<Point> previousCoords = new List<Point>();

        public void rotatePiece(LargeBoard myBoard)
        {
            previousCoords.Clear();
            for (int i = 0; i < coordsOfSquare.Count; i++)
            {
                previousCoords.Add(coordsOfSquare[i]);
            }
            switch (pieceNo)
            {
                case 1:
                    switch (rotationAngle)
	                {
                        case 0:
                            Point coord0 = coordsOfSquare[0];
                            Point coord2 = coordsOfSquare[2];
                            Point coord3 = coordsOfSquare[3];
                            coord0.X -= 1;
                            coord0.Y += 1;
                            coord2.X += 1;
                            coord2.Y -= 1;
                            coord3.X += 2;
                            coord3.Y -= 2;
                            coordsOfSquare[0] = coord0;
                            coordsOfSquare[2] = coord2;
                            coordsOfSquare[3] = coord3;
                            rotationAngle = 90;
                            break;
                        case 90:
                            Point coord10 = coordsOfSquare[0];
                            Point coord12 = coordsOfSquare[2];
                            Point coord13 = coordsOfSquare[3];
                            coord10.X += 1;
                            coord10.Y += 1;
                            coord12.X -= 1;
                            coord12.Y -= 1;
                            coord13.X -= 2;
                            coord13.Y -= 2;
                            coordsOfSquare[0] = coord10;
                            coordsOfSquare[2] = coord12;
                            coordsOfSquare[3] = coord13;
                            rotationAngle = 180;
                            break;
                        case 180:
                            Point coord20 = coordsOfSquare[0];
                            Point coord22 = coordsOfSquare[2];
                            Point coord23 = coordsOfSquare[3];
                            coord20.X += 1;
                            coord20.Y -= 1;
                            coord22.X -= 1;
                            coord22.Y += 1;
                            coord23.X -= 2;
                            coord23.Y += 2;
                            coordsOfSquare[0] = coord20;
                            coordsOfSquare[2] = coord22;
                            coordsOfSquare[3] = coord23;
                            rotationAngle = 270;
                            break;
                        case 270:
                            Point coord30 = coordsOfSquare[0];
                            Point coord32 = coordsOfSquare[2];
                            Point coord33 = coordsOfSquare[3];
                            coord30.X -= 1;
                            coord30.Y -= 1;
                            coord32.X += 1;
                            coord32.Y += 1;
                            coord33.X += 2;
                            coord33.Y += 2;
                            coordsOfSquare[0] = coord30;
                            coordsOfSquare[2] = coord32;
                            coordsOfSquare[3] = coord33;
                            rotationAngle = 360;
                            break;
                        case 360:
                            Point coord40 = coordsOfSquare[0];
                            Point coord42 = coordsOfSquare[2];
                            Point coord43 = coordsOfSquare[3];
                            coord40.X -= 1;
                            coord40.Y += 1;
                            coord42.X += 1;
                            coord42.Y -= 1;
                            coord43.X += 2;
                            coord43.Y -= 2;
                            coordsOfSquare[0] = coord40;
                            coordsOfSquare[2] = coord42;
                            coordsOfSquare[3] = coord43;
                            rotationAngle = 90;
                            break;
		                default:
                            break;
	                }
                    break;
                case 2:
                    switch (rotationAngle)
                    {
                        case 0:
                            Point coord0 = coordsOfSquare[0];
                            Point coord2 = coordsOfSquare[2];
                            Point coord3 = coordsOfSquare[3];
                            coord0.X -= 1;
                            coord0.Y -= 1;
                            coord2.X -= 1;
                            coord2.Y += 1;
                            coord3.X -= 2;
                            coord3.Y += 2;
                            coordsOfSquare[0] = coord0;
                            coordsOfSquare[2] = coord2;
                            coordsOfSquare[3] = coord3;
                            rotationAngle = 90;
                            break;
                        case 90:
                            Point coord10 = coordsOfSquare[0];
                            Point coord12 = coordsOfSquare[2];
                            Point coord13 = coordsOfSquare[3];
                            coord10.X -= 1;
                            coord10.Y += 1;
                            coord12.X += 1;
                            coord12.Y += 1;
                            coord13.X += 2;
                            coord13.Y += 2;
                            coordsOfSquare[0] = coord10;
                            coordsOfSquare[2] = coord12;
                            coordsOfSquare[3] = coord13;
                            rotationAngle = 180;
                            break;
                        case 180:
                            Point coord20 = coordsOfSquare[0];
                            Point coord22 = coordsOfSquare[2];
                            Point coord23 = coordsOfSquare[3];
                            coord20.X += 1;
                            coord20.Y += 1;
                            coord22.X += 1;
                            coord22.Y -= 1;
                            coord23.X += 2;
                            coord23.Y -= 2;
                            coordsOfSquare[0] = coord20;
                            coordsOfSquare[2] = coord22;
                            coordsOfSquare[3] = coord23;
                            rotationAngle = 270;
                            break;
                        case 270:
                            Point coord30 = coordsOfSquare[0];
                            Point coord32 = coordsOfSquare[2];
                            Point coord33 = coordsOfSquare[3];
                            coord30.X += 1;
                            coord30.Y -= 1;
                            coord32.X -= 1;
                            coord32.Y -= 1;
                            coord33.X -= 2;
                            coord33.Y -= 2;
                            coordsOfSquare[0] = coord30;
                            coordsOfSquare[2] = coord32;
                            coordsOfSquare[3] = coord33;
                            rotationAngle = 360;
                            break;
                        case 360:
                            Point coord40 = coordsOfSquare[0];
                            Point coord42 = coordsOfSquare[2];
                            Point coord43 = coordsOfSquare[3];
                            coord40.X -= 1;
                            coord40.Y -= 1;
                            coord42.X -= 1;
                            coord42.Y += 1;
                            coord43.X -= 2;
                            coord43.Y += 2;
                            coordsOfSquare[0] = coord40;
                            coordsOfSquare[2] = coord42;
                            coordsOfSquare[3] = coord43;
                            rotationAngle = 90;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (rotationAngle)
                    {
                        case 0:
                            Point coord0 = coordsOfSquare[0];
                            Point coord2 = coordsOfSquare[2];
                            Point coord3 = coordsOfSquare[3];
                            coord0.X -= 1;
                            coord0.Y -= 1;
                            coord2.X += 1;
                            coord2.Y -= 1;
                            coord3.X += 2;
                            coord3.Y -= 2;
                            coordsOfSquare[0] = coord0;
                            coordsOfSquare[2] = coord2;
                            coordsOfSquare[3] = coord3;
                            rotationAngle = 90;
                            break;
                        case 90:
                            Point coord10 = coordsOfSquare[0];
                            Point coord12 = coordsOfSquare[2];
                            Point coord13 = coordsOfSquare[3];
                            coord10.X -= 1;
                            coord10.Y += 1;
                            coord12.X -= 1;
                            coord12.Y -= 1;
                            coord13.X -= 2;
                            coord13.Y -= 2;
                            coordsOfSquare[0] = coord10;
                            coordsOfSquare[2] = coord12;
                            coordsOfSquare[3] = coord13;
                            rotationAngle = 180;
                            break;
                        case 180:
                            Point coord20 = coordsOfSquare[0];
                            Point coord22 = coordsOfSquare[2];
                            Point coord23 = coordsOfSquare[3];
                            coord20.X += 1;
                            coord20.Y += 1;
                            coord22.X -= 1;
                            coord22.Y += 1;
                            coord23.X -= 2;
                            coord23.Y += 2;
                            coordsOfSquare[0] = coord20;
                            coordsOfSquare[2] = coord22;
                            coordsOfSquare[3] = coord23;
                            rotationAngle = 270;
                            break;
                        case 270:
                            Point coord30 = coordsOfSquare[0];
                            Point coord32 = coordsOfSquare[2];
                            Point coord33 = coordsOfSquare[3];
                            coord30.X += 1;
                            coord30.Y -= 1;
                            coord32.X += 1;
                            coord32.Y += 1;
                            coord33.X += 2;
                            coord33.Y += 2;
                            coordsOfSquare[0] = coord30;
                            coordsOfSquare[2] = coord32;
                            coordsOfSquare[3] = coord33;
                            rotationAngle = 360;
                            break;
                        case 360:
                            Point coord40 = coordsOfSquare[0];
                            Point coord42 = coordsOfSquare[2];
                            Point coord43 = coordsOfSquare[3];
                            coord40.X -= 1;
                            coord40.Y -= 1;
                            coord42.X += 1;
                            coord42.Y -= 1;
                            coord43.X += 2;
                            coord43.Y -= 2;
                            coordsOfSquare[0] = coord40;
                            coordsOfSquare[2] = coord42;
                            coordsOfSquare[3] = coord43;
                            rotationAngle = 90;
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    switch (rotationAngle)
                    {
                        case 0:
                            Point coord0 = coordsOfSquare[0];
                            Point coord2 = coordsOfSquare[2];
                            Point coord3 = coordsOfSquare[3];
                            coord0.X += 1;
                            coord0.Y -= 1;
                            coord2.X += 1;
                            coord2.Y += 1;
                            coord3.Y += 2;
                            coordsOfSquare[0] = coord0;
                            coordsOfSquare[2] = coord2;
                            coordsOfSquare[3] = coord3;
                            rotationAngle = 90;
                            break;
                        case 90:
                            Point coord10 = coordsOfSquare[0];
                            Point coord12 = coordsOfSquare[2];
                            Point coord13 = coordsOfSquare[3];
                            coord10.X -= 1;
                            coord10.Y -= 1;
                            coord12.X += 1;
                            coord12.Y -= 1;
                            coord13.X += 2;
                            coordsOfSquare[0] = coord10;
                            coordsOfSquare[2] = coord12;
                            coordsOfSquare[3] = coord13;
                            rotationAngle = 180;
                            break;
                        case 180: 
                            Point coord20 = coordsOfSquare[0];
                            Point coord22 = coordsOfSquare[2];
                            Point coord23 = coordsOfSquare[3];
                            coord20.X -= 1;
                            coord20.Y += 1;
                            coord22.X -= 1;
                            coord22.Y -= 1;
                            coord23.Y -= 2;
                            coordsOfSquare[0] = coord20;
                            coordsOfSquare[2] = coord22;
                            coordsOfSquare[3] = coord23;
                            rotationAngle = 270;
                            break;
                        case 270:
                            Point coord30 = coordsOfSquare[0];
                            Point coord32 = coordsOfSquare[2];
                            Point coord33 = coordsOfSquare[3];
                            coord30.X += 1;
                            coord30.Y += 1;
                            coord32.X -= 1;
                            coord32.Y += 1;
                            coord33.X -= 2;
                            coordsOfSquare[0] = coord30;
                            coordsOfSquare[2] = coord32;
                            coordsOfSquare[3] = coord33;
                            rotationAngle = 360;
                            break;
                        case 360:
                            Point coord40 = coordsOfSquare[0];
                            Point coord42 = coordsOfSquare[2];
                            Point coord43 = coordsOfSquare[3];
                            coord40.X += 1;
                            coord40.Y -= 1;
                            coord42.X += 1;
                            coord42.Y += 1;
                            coord43.Y += 2;
                            coordsOfSquare[0] = coord40;
                            coordsOfSquare[2] = coord42;
                            coordsOfSquare[3] = coord43;
                            rotationAngle = 90;
                            break;
                        default:
                            break;
                    }
                    break;
                case 6:
                    switch (rotationAngle)
                    {
                        case 0:
                            Point coord0 = coordsOfSquare[0];
                            Point coord2 = coordsOfSquare[2];
                            Point coord3 = coordsOfSquare[3];
                            coord0.X -= 1;
                            coord0.Y -= 1;
                            coord2.X -= 1;
                            coord2.Y += 1;
                            coord3.X += 1;
                            coord3.Y -= 1;
                            coordsOfSquare[0] = coord0;
                            coordsOfSquare[2] = coord2;
                            coordsOfSquare[3] = coord3;
                            rotationAngle = 90;
                            break;
                        case 90:
                            Point coord10 = coordsOfSquare[0];
                            Point coord12 = coordsOfSquare[2];
                            Point coord13 = coordsOfSquare[3];
                            coord10.X -= 1;
                            coord10.Y += 1;
                            coord12.X += 1;
                            coord12.Y += 1;
                            coord13.X -= 1;
                            coord13.Y -= 1;
                            coordsOfSquare[0] = coord10;
                            coordsOfSquare[2] = coord12;
                            coordsOfSquare[3] = coord13;
                            rotationAngle = 180;
                            break;
                        case 180:
                            Point coord20 = coordsOfSquare[0];
                            Point coord22 = coordsOfSquare[2];
                            Point coord23 = coordsOfSquare[3];
                            coord20.X += 1;
                            coord20.Y += 1;
                            coord22.X += 1;
                            coord22.Y -= 1;
                            coord23.X -= 1;
                            coord23.Y += 1;
                            coordsOfSquare[0] = coord20;
                            coordsOfSquare[2] = coord22;
                            coordsOfSquare[3] = coord23;
                            rotationAngle = 270;
                            break;
                        case 270:
                            Point coord30 = coordsOfSquare[0];
                            Point coord32 = coordsOfSquare[2];
                            Point coord33 = coordsOfSquare[3];
                            coord30.X += 1;
                            coord30.Y -= 1;
                            coord32.X -= 1;
                            coord32.Y -= 1;
                            coord33.X += 1;
                            coord33.Y += 1;
                            coordsOfSquare[0] = coord30;
                            coordsOfSquare[2] = coord32;
                            coordsOfSquare[3] = coord33;
                            rotationAngle = 360;
                            break;
                        case 360:
                            Point coord40 = coordsOfSquare[0];
                            Point coord42 = coordsOfSquare[2];
                            Point coord43 = coordsOfSquare[3];
                            coord40.X -= 1;
                            coord40.Y -= 1;
                            coord42.X -= 1;
                            coord42.Y += 1;
                            coord43.X += 1;
                            coord43.Y -= 1;
                            coordsOfSquare[0] = coord40;
                            coordsOfSquare[2] = coord42;
                            coordsOfSquare[3] = coord43;
                            rotationAngle = 90;
                            break;
                        default:
                            break;
                    }
                    break;
                case 7:
                    switch (rotationAngle)
	                {
                        case 0:
                            Point coord0 = coordsOfSquare[0];
                            Point coord2 = coordsOfSquare[2];
                            Point coord3 = coordsOfSquare[3];
                            coord0.X -= 1;
                            coord0.Y += 1;
                            coord2.X += 1;
                            coord2.Y += 1;
                            coord3.X += 2;
                            coordsOfSquare[0] = coord0;
                            coordsOfSquare[2] = coord2;
                            coordsOfSquare[3] = coord3;
                            rotationAngle = 90;
                            break;
                        case 90:
                            Point coord10 = coordsOfSquare[0];
                            Point coord12 = coordsOfSquare[2];
                            Point coord13 = coordsOfSquare[3];
                            coord10.X += 1;
                            coord10.Y += 1;
                            coord12.X += 1;
                            coord12.Y -= 1;
                            coord13.Y -= 2;
                            coordsOfSquare[0] = coord10;
                            coordsOfSquare[2] = coord12;
                            coordsOfSquare[3] = coord13;
                            rotationAngle = 180;
                            break;
                        case 180:
                            Point coord20 = coordsOfSquare[0];
                            Point coord22 = coordsOfSquare[2];
                            Point coord23 = coordsOfSquare[3];
                            coord20.X += 1;
                            coord20.Y -= 1;
                            coord22.X -= 1;
                            coord22.Y -= 1;
                            coord23.X -= 2;
                            coordsOfSquare[0] = coord20;
                            coordsOfSquare[2] = coord22;
                            coordsOfSquare[3] = coord23;
                            rotationAngle = 270;
                            break;
                        case 270:
                            Point coord30 = coordsOfSquare[0];
                            Point coord32 = coordsOfSquare[2];
                            Point coord33 = coordsOfSquare[3];
                            coord30.X -= 1;
                            coord30.Y -= 1;
                            coord32.X -= 1;
                            coord32.Y += 1;
                            coord33.Y += 2;
                            coordsOfSquare[0] = coord30;
                            coordsOfSquare[2] = coord32;
                            coordsOfSquare[3] = coord33;
                            rotationAngle = 360;
                            break;
                        case 360:
                            Point coord40 = coordsOfSquare[0];
                            Point coord42 = coordsOfSquare[2];
                            Point coord43 = coordsOfSquare[3];
                            coord40.X -= 1;
                            coord40.Y += 1;
                            coord42.X += 1;
                            coord42.Y += 1;
                            coord43.X += 2;
                            coordsOfSquare[0] = coord40;
                            coordsOfSquare[2] = coord42;
                            coordsOfSquare[3] = coord43;
                            rotationAngle = 90;
                            break;
		                default:
                            break;
                            
	                }
                    break;
                default:
                    break;
            }
            if (isTouchingBottomWall(myBoard.occupiedSquares) || isTouchingBottomOfPiece(myBoard.occupiedSquares) || arePointsOutside())
            {
                for (int i = 0; i < coordsOfSquare.Count; i++)
                    coordsOfSquare[i] = previousCoords[i];
                if (rotationAngle > 0)
                    rotationAngle -= 90;
            }
        }

        private bool arePointsOutside()
        {
            for (int i = 0; i < coordsOfSquare.Count; i++)
            {
                Point coord = coordsOfSquare[i];
                if (coord.X < 1 || coord.Y > 10 || coord.Y < 1)
                    return true;
            }
            return false;
        }

        #region isTouching

        public bool isTouchingBottomOfPiece(List<Square> occupiedSquares)
        {
            for (int i = 0; i < coordsOfSquare.Count; i++)
            {
                Point coord = coordsOfSquare[i];
                for (int a = 0; a < occupiedSquares.Count; a++)
                {
                    if (coord.X + 1 == occupiedSquares[a].coord.X && coord.Y == occupiedSquares[a].coord.Y)
                        return true;
                }
            }
            return false;
        }

        public bool isTouchingBottomWall(List<Square> occupiedSquares)
        {
            for (int u = 0; u < coordsOfSquare.Count; u++)
                if (coordsOfSquare[u].X == 20)
                    return true;
            return false;
        }

        public bool isTouchingLeftOfPiece(List<Square> occupiedSquares)
        {
            for (int i = 0; i < coordsOfSquare.Count; i++)
            {
                Point coord = coordsOfSquare[i];
                for (int a = 0; a < occupiedSquares.Count; a++)
                    if (coord.Y - 1 == occupiedSquares[a].coord.Y && coord.X == occupiedSquares[a].coord.X)
                        return true;
            }
            return false;
        }

        public bool isTouchingLeftWall(List<Square> occupiedSquares)
        {
            bool isTouching = false;
            for (int i = 0; i < coordsOfSquare.Count; i++)
            {
                Point coord = coordsOfSquare[i];
                if (coord.Y == 1)
                    isTouching = true;
            }
            return isTouching;
        }

        public bool isTouchingRightWall(List<Square> occupiedSquares)
        {
            for (int i = 0; i < coordsOfSquare.Count; i++)
            {
                Point coord = coordsOfSquare[i];
                if (coord.Y == 10)
                    return true;
            }
            return false;
        }

        public bool isTouchingRightOfPiece(List<Square> occupiedSquares)
        {
            for (int i = 0; i < coordsOfSquare.Count; i++)
            {
                Point coord = coordsOfSquare[i];
                for (int a = 0; a < occupiedSquares.Count; a++)
                    if (coord.Y + 1 == occupiedSquares[a].coord.Y && coord.X == occupiedSquares[a].coord.X)
                        return true;
            }
            return false;
        }

        #endregion
    }
}
