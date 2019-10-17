using System;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        public LijnenVoorraad LijnenVoorraad { get; }
        public Kabel Kabel { get; }

        private Random random = new Random();

        public Waterskibaan()
        {
            LijnenVoorraad = new LijnenVoorraad();
            Kabel = new Kabel();
            for (int i = 1; i <= 15; i++)
            {
                LijnenVoorraad.LijnToevoegenAanRij(new Lijn(i));
            }
        }

        public void VerplaatsKabel()
        {
            Kabel.VerschuifLijnen();
            Lijn lijn = Kabel.VerwijderLijnVanKabel();
            if (lijn != null)
            {
                LijnenVoorraad.LijnToevoegenAanRij(lijn);
            }

            foreach (Lijn sporterLijn in Kabel.Lijnen)
            {
                if (sporterLijn.Sporter != null)
                {
                    if (sporterLijn.Sporter.HuidigeMove != null)
                    {
                        sporterLijn.Sporter.HuidigeMove = null;
                    }

                    if (random.Next(4) == 0 && sporterLijn.Sporter.Moves.Count > 0)
                    {
                        int randomMove = random.Next(sporterLijn.Sporter.Moves.Count);
                        IMove move = sporterLijn.Sporter.Moves[randomMove];
                        sporterLijn.Sporter.HuidigeMove = move;
                        if (random.Next(4) != 0)
                        {
                            sporterLijn.Sporter.BehaaldePunten += move.Move();
                        }
                        sporterLijn.Sporter.Moves.RemoveAt(randomMove);
                    }
                }
            }
        }

        public void SporterStart(Sporter sporter)
        {
            if (sporter.Skies == null || sporter.Zwemvest == null)
            {
                throw new ArgumentException("Sporter heeft geen skies of zwemvest");
            }
            Lijn lijn = LijnenVoorraad.VerwijderEersteLijn();
            lijn.Sporter = sporter;
            Random r = new Random();
            sporter.AantalRondenNogTeGaan = r.Next(2) + 1;
            Kabel.NeemLijnInGebruik(lijn);
        }

        public override string ToString()
        {
            return "De waterskibaan heeft " + LijnenVoorraad + " op de kabel " + Kabel;
        }
    }
}