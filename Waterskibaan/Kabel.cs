using System;
using System.Collections.Generic;
using System.Linq;

namespace Waterskibaan
{
    public class Kabel
    {
        public LinkedList<Lijn> Lijnen { get; } = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (Lijnen.Count == 0 || Lijnen.First.Value.PositieOpDeKabel != 0)
            {
                return true;
            }

            return false;
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                lijn.PositieOpDeKabel = 0;
                Lijnen.AddFirst(lijn);
            }
            else
            {
                Console.WriteLine("Kon de lijn niet in gebruik nemen omdat de start positie niet leeg is");
            }
        }

        public void VerschuifLijnen()
        {
            bool moveToStart = false;
            foreach (Lijn lijn in Lijnen)
            {
                lijn.PositieOpDeKabel++;
                if (lijn.PositieOpDeKabel == 10)
                {
                    moveToStart = true;
                }
            }

            if (moveToStart)
            {
                Lijn lijn = Lijnen.Last.Value;
                lijn.PositieOpDeKabel = 0;
                if (lijn.Sporter != null)
                {
                    lijn.Sporter.AantalRondenNogTeGaan--;
                }
                Lijnen.RemoveLast();
                Lijnen.AddFirst(lijn);
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            if (Lijnen.Last != null && Lijnen.Last.Value.PositieOpDeKabel == 9)
            {
                Lijn lastLijn = Lijnen.Last.Value;
                if (lastLijn.Sporter == null || lastLijn.Sporter.AantalRondenNogTeGaan == 1)
                {
                    // Verwijder de lijn uit de list als er geen sporter is of als de sporter in het laatste rondje zit
                    Lijnen.RemoveLast();
                    return lastLijn;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return string.Join("|", Lijnen.Select(m => m.PositieOpDeKabel).ToArray());
        }
    }
}