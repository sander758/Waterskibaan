using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Waterskibaan
{
    public class Logger
    {
        private Kabel kabel;
        public List<Sporter> Sporters { get; set; }

        public Logger(Kabel kabel)
        {
            this.kabel = kabel;
            Sporters = new List<Sporter>();
        }

        public void OnNieuweBezoeker(NieuweBezoekerArgs args)
        {
            Sporters.Add(args.Sporter);
        }

        public int AantalBezoekers()
        {
            return Sporters.Count();
        }

        public int HoogsteScore()
        {
            Sporter sporter = Sporters.OrderByDescending(s => s.BehaaldePunten).First();
            if (sporter != null)
            {
                return sporter.BehaaldePunten;
            }
            return 0;
        }

        public int TotaalAantalRondjes()
        {
            return Sporters.Sum(s => s.AfgelegdeRondjes);
        }

        public int[] UniekeMoves()
        {
            int[] uniekeMoves = {0, 0, 0, 0};

            uniekeMoves[0] = kabel.Lijnen.Count(lijn => lijn.Sporter.HuidigeMove is SpringMove);
            uniekeMoves[1] = kabel.Lijnen.Count(lijn => lijn.Sporter.HuidigeMove is OmdraaiMove);
            uniekeMoves[2] = kabel.Lijnen.Count(lijn => lijn.Sporter.HuidigeMove is EenHandMove);
            uniekeMoves[3] = kabel.Lijnen.Count(lijn => lijn.Sporter.HuidigeMove is EenBeenMove);

            return uniekeMoves;
        }

        public int RodeKleding()
        {
            Color color = Color.Red;
            return Sporters.Count(s => ColorsAreClose(color, s.KledingKleur));
        }

        public bool ColorsAreClose(Color a, Color z, int threshold = 100)
        {
            int r = (int) a.R - z.R,
                g = (int) a.G - z.G,
                b = (int) a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        public List<Sporter> LichtsteKleding()
        {
            return new List<Sporter>(Sporters.OrderByDescending(s => ColorBrightness(s.KledingKleur)).Take(10));
        }

        private int ColorBrightness(Color color)
        {
            return color.R * color.R + color.G * color.G + color.B * color.B;
        }
    }
}