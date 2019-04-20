using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Tetris
{
    public class Detale
    {
        public Detale()
        {

        }
        public List<Point> LangeliuKoord = new List<Point>();
        public int DetalesNr; // 1 - pailga; 2 - 1,3; 3 - 3,1; 4 - kvadratas; 5 - zigzag; 6 - T; 7 - zigzag
        public int PasukimoKampas;
        public Color Spalva;
        private List<Point> BuvusiosKoord = new List<Point>();

        public void DetalesPasukimas(Board myBoard)
        {
            BuvusiosKoord.Clear();
            for (int i = 0; i < LangeliuKoord.Count; i++)
            {
                BuvusiosKoord.Add(LangeliuKoord[i]);
            }
            switch (DetalesNr)
            {
                case 1:
                    switch (PasukimoKampas)
	                {
                        case 0:
                            Point koord0 = LangeliuKoord[0];
                            Point koord2 = LangeliuKoord[2];
                            Point koord3 = LangeliuKoord[3];
                            koord0.X -= 1;
                            koord0.Y += 1;
                            koord2.X += 1;
                            koord2.Y -= 1;
                            koord3.X += 2;
                            koord3.Y -= 2;
                            LangeliuKoord[0] = koord0;
                            LangeliuKoord[2] = koord2;
                            LangeliuKoord[3] = koord3;
                            PasukimoKampas = 90;
                            break;
                        case 90:
                            Point koord10 = LangeliuKoord[0];
                            Point koord12 = LangeliuKoord[2];
                            Point koord13 = LangeliuKoord[3];
                            koord10.X += 1;
                            koord10.Y += 1;
                            koord12.X -= 1;
                            koord12.Y -= 1;
                            koord13.X -= 2;
                            koord13.Y -= 2;
                            LangeliuKoord[0] = koord10;
                            LangeliuKoord[2] = koord12;
                            LangeliuKoord[3] = koord13;
                            PasukimoKampas = 180;
                            break;
                        case 180:
                            Point koord20 = LangeliuKoord[0];
                            Point koord22 = LangeliuKoord[2];
                            Point koord23 = LangeliuKoord[3];
                            koord20.X += 1;
                            koord20.Y -= 1;
                            koord22.X -= 1;
                            koord22.Y += 1;
                            koord23.X -= 2;
                            koord23.Y += 2;
                            LangeliuKoord[0] = koord20;
                            LangeliuKoord[2] = koord22;
                            LangeliuKoord[3] = koord23;
                            PasukimoKampas = 270;
                            break;
                        case 270:
                            Point koord30 = LangeliuKoord[0];
                            Point koord32 = LangeliuKoord[2];
                            Point koord33 = LangeliuKoord[3];
                            koord30.X -= 1;
                            koord30.Y -= 1;
                            koord32.X += 1;
                            koord32.Y += 1;
                            koord33.X += 2;
                            koord33.Y += 2;
                            LangeliuKoord[0] = koord30;
                            LangeliuKoord[2] = koord32;
                            LangeliuKoord[3] = koord33;
                            PasukimoKampas = 360;
                            break;
                        case 360:
                            Point koord40 = LangeliuKoord[0];
                            Point koord42 = LangeliuKoord[2];
                            Point koord43 = LangeliuKoord[3];
                            koord40.X -= 1;
                            koord40.Y += 1;
                            koord42.X += 1;
                            koord42.Y -= 1;
                            koord43.X += 2;
                            koord43.Y -= 2;
                            LangeliuKoord[0] = koord40;
                            LangeliuKoord[2] = koord42;
                            LangeliuKoord[3] = koord43;
                            PasukimoKampas = 90;
                            break;
		                default:
                            break;
	                }
                    break;
                case 2:
                    switch (PasukimoKampas)
                    {
                        case 0:
                            Point koord0 = LangeliuKoord[0];
                            Point koord2 = LangeliuKoord[2];
                            Point koord3 = LangeliuKoord[3];
                            koord0.X -= 1;
                            koord0.Y -= 1;
                            koord2.X -= 1;
                            koord2.Y += 1;
                            koord3.X -= 2;
                            koord3.Y += 2;
                            LangeliuKoord[0] = koord0;
                            LangeliuKoord[2] = koord2;
                            LangeliuKoord[3] = koord3;
                            PasukimoKampas = 90;
                            break;
                        case 90:
                            Point koord10 = LangeliuKoord[0];
                            Point koord12 = LangeliuKoord[2];
                            Point koord13 = LangeliuKoord[3];
                            koord10.X -= 1;
                            koord10.Y += 1;
                            koord12.X += 1;
                            koord12.Y += 1;
                            koord13.X += 2;
                            koord13.Y += 2;
                            LangeliuKoord[0] = koord10;
                            LangeliuKoord[2] = koord12;
                            LangeliuKoord[3] = koord13;
                            PasukimoKampas = 180;
                            break;
                        case 180:
                            Point koord20 = LangeliuKoord[0];
                            Point koord22 = LangeliuKoord[2];
                            Point koord23 = LangeliuKoord[3];
                            koord20.X += 1;
                            koord20.Y += 1;
                            koord22.X += 1;
                            koord22.Y -= 1;
                            koord23.X += 2;
                            koord23.Y -= 2;
                            LangeliuKoord[0] = koord20;
                            LangeliuKoord[2] = koord22;
                            LangeliuKoord[3] = koord23;
                            PasukimoKampas = 270;
                            break;
                        case 270:
                            Point koord30 = LangeliuKoord[0];
                            Point koord32 = LangeliuKoord[2];
                            Point koord33 = LangeliuKoord[3];
                            koord30.X += 1;
                            koord30.Y -= 1;
                            koord32.X -= 1;
                            koord32.Y -= 1;
                            koord33.X -= 2;
                            koord33.Y -= 2;
                            LangeliuKoord[0] = koord30;
                            LangeliuKoord[2] = koord32;
                            LangeliuKoord[3] = koord33;
                            PasukimoKampas = 360;
                            break;
                        case 360:
                            Point koord40 = LangeliuKoord[0];
                            Point koord42 = LangeliuKoord[2];
                            Point koord43 = LangeliuKoord[3];
                            koord40.X -= 1;
                            koord40.Y -= 1;
                            koord42.X -= 1;
                            koord42.Y += 1;
                            koord43.X -= 2;
                            koord43.Y += 2;
                            LangeliuKoord[0] = koord40;
                            LangeliuKoord[2] = koord42;
                            LangeliuKoord[3] = koord43;
                            PasukimoKampas = 90;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (PasukimoKampas)
                    {
                        case 0:
                            Point koord0 = LangeliuKoord[0];
                            Point koord2 = LangeliuKoord[2];
                            Point koord3 = LangeliuKoord[3];
                            koord0.X -= 1;
                            koord0.Y -= 1;
                            koord2.X += 1;
                            koord2.Y -= 1;
                            koord3.X += 2;
                            koord3.Y -= 2;
                            LangeliuKoord[0] = koord0;
                            LangeliuKoord[2] = koord2;
                            LangeliuKoord[3] = koord3;
                            PasukimoKampas = 90;
                            break;
                        case 90:
                            Point koord10 = LangeliuKoord[0];
                            Point koord12 = LangeliuKoord[2];
                            Point koord13 = LangeliuKoord[3];
                            koord10.X -= 1;
                            koord10.Y += 1;
                            koord12.X -= 1;
                            koord12.Y -= 1;
                            koord13.X -= 2;
                            koord13.Y -= 2;
                            LangeliuKoord[0] = koord10;
                            LangeliuKoord[2] = koord12;
                            LangeliuKoord[3] = koord13;
                            PasukimoKampas = 180;
                            break;
                        case 180:
                            Point koord20 = LangeliuKoord[0];
                            Point koord22 = LangeliuKoord[2];
                            Point koord23 = LangeliuKoord[3];
                            koord20.X += 1;
                            koord20.Y += 1;
                            koord22.X -= 1;
                            koord22.Y += 1;
                            koord23.X -= 2;
                            koord23.Y += 2;
                            LangeliuKoord[0] = koord20;
                            LangeliuKoord[2] = koord22;
                            LangeliuKoord[3] = koord23;
                            PasukimoKampas = 270;
                            break;
                        case 270:
                            Point koord30 = LangeliuKoord[0];
                            Point koord32 = LangeliuKoord[2];
                            Point koord33 = LangeliuKoord[3];
                            koord30.X += 1;
                            koord30.Y -= 1;
                            koord32.X += 1;
                            koord32.Y += 1;
                            koord33.X += 2;
                            koord33.Y += 2;
                            LangeliuKoord[0] = koord30;
                            LangeliuKoord[2] = koord32;
                            LangeliuKoord[3] = koord33;
                            PasukimoKampas = 360;
                            break;
                        case 360:
                            Point koord40 = LangeliuKoord[0];
                            Point koord42 = LangeliuKoord[2];
                            Point koord43 = LangeliuKoord[3];
                            koord40.X -= 1;
                            koord40.Y -= 1;
                            koord42.X += 1;
                            koord42.Y -= 1;
                            koord43.X += 2;
                            koord43.Y -= 2;
                            LangeliuKoord[0] = koord40;
                            LangeliuKoord[2] = koord42;
                            LangeliuKoord[3] = koord43;
                            PasukimoKampas = 90;
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    switch (PasukimoKampas)
                    {
                        case 0:
                            Point koord0 = LangeliuKoord[0];
                            Point koord2 = LangeliuKoord[2];
                            Point koord3 = LangeliuKoord[3];
                            koord0.X += 1;
                            koord0.Y -= 1;
                            koord2.X += 1;
                            koord2.Y += 1;
                            koord3.Y += 2;
                            LangeliuKoord[0] = koord0;
                            LangeliuKoord[2] = koord2;
                            LangeliuKoord[3] = koord3;
                            PasukimoKampas = 90;
                            break;
                        case 90:
                            Point koord10 = LangeliuKoord[0];
                            Point koord12 = LangeliuKoord[2];
                            Point koord13 = LangeliuKoord[3];
                            koord10.X -= 1;
                            koord10.Y -= 1;
                            koord12.X += 1;
                            koord12.Y -= 1;
                            koord13.X += 2;
                            LangeliuKoord[0] = koord10;
                            LangeliuKoord[2] = koord12;
                            LangeliuKoord[3] = koord13;
                            PasukimoKampas = 180;
                            break;
                        case 180: 
                            Point koord20 = LangeliuKoord[0];
                            Point koord22 = LangeliuKoord[2];
                            Point koord23 = LangeliuKoord[3];
                            koord20.X -= 1;
                            koord20.Y += 1;
                            koord22.X -= 1;
                            koord22.Y -= 1;
                            koord23.Y -= 2;
                            LangeliuKoord[0] = koord20;
                            LangeliuKoord[2] = koord22;
                            LangeliuKoord[3] = koord23;
                            PasukimoKampas = 270;
                            break;
                        case 270:
                            Point koord30 = LangeliuKoord[0];
                            Point koord32 = LangeliuKoord[2];
                            Point koord33 = LangeliuKoord[3];
                            koord30.X += 1;
                            koord30.Y += 1;
                            koord32.X -= 1;
                            koord32.Y += 1;
                            koord33.X -= 2;
                            LangeliuKoord[0] = koord30;
                            LangeliuKoord[2] = koord32;
                            LangeliuKoord[3] = koord33;
                            PasukimoKampas = 360;
                            break;
                        case 360:
                            Point koord40 = LangeliuKoord[0];
                            Point koord42 = LangeliuKoord[2];
                            Point koord43 = LangeliuKoord[3];
                            koord40.X += 1;
                            koord40.Y -= 1;
                            koord42.X += 1;
                            koord42.Y += 1;
                            koord43.Y += 2;
                            LangeliuKoord[0] = koord40;
                            LangeliuKoord[2] = koord42;
                            LangeliuKoord[3] = koord43;
                            PasukimoKampas = 90;
                            break;
                        default:
                            break;
                    }
                    break;
                case 6:
                    switch (PasukimoKampas)
                    {
                        case 0:
                            Point koord0 = LangeliuKoord[0];
                            Point koord2 = LangeliuKoord[2];
                            Point koord3 = LangeliuKoord[3];
                            koord0.X -= 1;
                            koord0.Y -= 1;
                            koord2.X -= 1;
                            koord2.Y += 1;
                            koord3.X += 1;
                            koord3.Y -= 1;
                            LangeliuKoord[0] = koord0;
                            LangeliuKoord[2] = koord2;
                            LangeliuKoord[3] = koord3;
                            PasukimoKampas = 90;
                            break;
                        case 90:
                            Point koord10 = LangeliuKoord[0];
                            Point koord12 = LangeliuKoord[2];
                            Point koord13 = LangeliuKoord[3];
                            koord10.X -= 1;
                            koord10.Y += 1;
                            koord12.X += 1;
                            koord12.Y += 1;
                            koord13.X -= 1;
                            koord13.Y -= 1;
                            LangeliuKoord[0] = koord10;
                            LangeliuKoord[2] = koord12;
                            LangeliuKoord[3] = koord13;
                            PasukimoKampas = 180;
                            break;
                        case 180:
                            Point koord20 = LangeliuKoord[0];
                            Point koord22 = LangeliuKoord[2];
                            Point koord23 = LangeliuKoord[3];
                            koord20.X += 1;
                            koord20.Y += 1;
                            koord22.X += 1;
                            koord22.Y -= 1;
                            koord23.X -= 1;
                            koord23.Y += 1;
                            LangeliuKoord[0] = koord20;
                            LangeliuKoord[2] = koord22;
                            LangeliuKoord[3] = koord23;
                            PasukimoKampas = 270;
                            break;
                        case 270:
                            Point koord30 = LangeliuKoord[0];
                            Point koord32 = LangeliuKoord[2];
                            Point koord33 = LangeliuKoord[3];
                            koord30.X += 1;
                            koord30.Y -= 1;
                            koord32.X -= 1;
                            koord32.Y -= 1;
                            koord33.X += 1;
                            koord33.Y += 1;
                            LangeliuKoord[0] = koord30;
                            LangeliuKoord[2] = koord32;
                            LangeliuKoord[3] = koord33;
                            PasukimoKampas = 360;
                            break;
                        case 360:
                            Point koord40 = LangeliuKoord[0];
                            Point koord42 = LangeliuKoord[2];
                            Point koord43 = LangeliuKoord[3];
                            koord40.X -= 1;
                            koord40.Y -= 1;
                            koord42.X -= 1;
                            koord42.Y += 1;
                            koord43.X += 1;
                            koord43.Y -= 1;
                            LangeliuKoord[0] = koord40;
                            LangeliuKoord[2] = koord42;
                            LangeliuKoord[3] = koord43;
                            PasukimoKampas = 90;
                            break;
                        default:
                            break;
                    }
                    break;
                case 7:
                    switch (PasukimoKampas)
	                {
                        case 0:
                            Point koord0 = LangeliuKoord[0];
                            Point koord2 = LangeliuKoord[2];
                            Point koord3 = LangeliuKoord[3];
                            koord0.X -= 1;
                            koord0.Y += 1;
                            koord2.X += 1;
                            koord2.Y += 1;
                            koord3.X += 2;
                            LangeliuKoord[0] = koord0;
                            LangeliuKoord[2] = koord2;
                            LangeliuKoord[3] = koord3;
                            PasukimoKampas = 90;
                            break;
                        case 90:
                            Point koord10 = LangeliuKoord[0];
                            Point koord12 = LangeliuKoord[2];
                            Point koord13 = LangeliuKoord[3];
                            koord10.X += 1;
                            koord10.Y += 1;
                            koord12.X += 1;
                            koord12.Y -= 1;
                            koord13.Y -= 2;
                            LangeliuKoord[0] = koord10;
                            LangeliuKoord[2] = koord12;
                            LangeliuKoord[3] = koord13;
                            PasukimoKampas = 180;
                            break;
                        case 180:
                            Point koord20 = LangeliuKoord[0];
                            Point koord22 = LangeliuKoord[2];
                            Point koord23 = LangeliuKoord[3];
                            koord20.X += 1;
                            koord20.Y -= 1;
                            koord22.X -= 1;
                            koord22.Y -= 1;
                            koord23.X -= 2;
                            LangeliuKoord[0] = koord20;
                            LangeliuKoord[2] = koord22;
                            LangeliuKoord[3] = koord23;
                            PasukimoKampas = 270;
                            break;
                        case 270:
                            Point koord30 = LangeliuKoord[0];
                            Point koord32 = LangeliuKoord[2];
                            Point koord33 = LangeliuKoord[3];
                            koord30.X -= 1;
                            koord30.Y -= 1;
                            koord32.X -= 1;
                            koord32.Y += 1;
                            koord33.Y += 2;
                            LangeliuKoord[0] = koord30;
                            LangeliuKoord[2] = koord32;
                            LangeliuKoord[3] = koord33;
                            PasukimoKampas = 360;
                            break;
                        case 360:
                            Point koord40 = LangeliuKoord[0];
                            Point koord42 = LangeliuKoord[2];
                            Point koord43 = LangeliuKoord[3];
                            koord40.X -= 1;
                            koord40.Y += 1;
                            koord42.X += 1;
                            koord42.Y += 1;
                            koord43.X += 2;
                            LangeliuKoord[0] = koord40;
                            LangeliuKoord[2] = koord42;
                            LangeliuKoord[3] = koord43;
                            PasukimoKampas = 90;
                            break;
		                default:
                            break;
                            
	                }
                    break;
                default:
                    break;
            }
            if (this.ArLieciaApatineSiena(myBoard.UzimtiLangeliai) || this.ArLieciaDetalesApacia(myBoard.UzimtiLangeliai) || ArIssikisaTaskai()) // Kaip šitą būtų galima padaryt protingiau?
            {
                for (int i = 0; i < LangeliuKoord.Count; i++)
                    LangeliuKoord[i] = BuvusiosKoord[i];
                if (PasukimoKampas > 0)
                    PasukimoKampas -= 90;
            }
        }

        private bool ArIssikisaTaskai()
        {
            for (int i = 0; i < LangeliuKoord.Count; i++)
            {
                Point koord = LangeliuKoord[i];
                if (koord.X < 1 || koord.Y > 10 || koord.Y < 1)
                    return true;
            }
            return false;
        }

        #region ArLiecia

        public bool ArLieciaDetalesApacia(List<Langelis> UzimtiLangeliai)
        {
            for (int i = 0; i < LangeliuKoord.Count; i++)
            {
                Point koord = LangeliuKoord[i];
                for (int a = 0; a < UzimtiLangeliai.Count; a++)
                {
                    if (koord.X + 1 == UzimtiLangeliai[a].Koord.X && koord.Y == UzimtiLangeliai[a].Koord.Y)
                        return true;
                }
            }
            return false;
        }

        public bool ArLieciaApatineSiena(List<Langelis> UzimtiLangeliai)
        {
            for (int u = 0; u < LangeliuKoord.Count; u++)
                if (LangeliuKoord[u].X == 20)
                    return true;
            return false;
        }

        public bool ArLieciaDetalesKaire(List<Langelis> UzimtiLangeliai)
        {
            for (int i = 0; i < LangeliuKoord.Count; i++)
            {
                Point koord = LangeliuKoord[i];
                for (int a = 0; a < UzimtiLangeliai.Count; a++)
                    if (koord.Y - 1 == UzimtiLangeliai[a].Koord.Y && koord.X == UzimtiLangeliai[a].Koord.X)
                        return true;
            }
            return false;
        }

        public bool ArLieciaKaireSiena(List<Langelis> UzimtiLangeliai)
        {
            bool ArSiekia = false;
            for (int i = 0; i < LangeliuKoord.Count; i++)
            {
                Point koord = LangeliuKoord[i];
                if (koord.Y == 1)
                    ArSiekia = true;
            }
            return ArSiekia;
        }

        public bool ArLieciaDesineSiena(List<Langelis> UzimtiLangeliai)
        {
            for (int i = 0; i < LangeliuKoord.Count; i++)
            {
                Point koord = LangeliuKoord[i];
                if (koord.Y == 10)
                    return true;
            }
            return false;
        }

        public bool ArLieciaDetalesDesine(List<Langelis> UzimtiLangeliai)
        {
            for (int i = 0; i < LangeliuKoord.Count; i++)
            {
                Point koord = LangeliuKoord[i];
                for (int a = 0; a < UzimtiLangeliai.Count; a++)
                    if (koord.Y + 1 == UzimtiLangeliai[a].Koord.Y && koord.X == UzimtiLangeliai[a].Koord.X)
                        return true;
            }
            return false;
        }

        #endregion
    }
}
