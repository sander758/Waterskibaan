using System;
using System.Collections.Generic;
using System.Linq;

namespace Waterskibaan
{
    public class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (_lijnen.Count == 0 || _lijnen.First.Value.PositieOpDeKabel != 0)
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
                _lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen()
        {
            bool moveToStart = false;
            foreach (Lijn lijn in _lijnen)
            {
                lijn.PositieOpDeKabel++;
                if (lijn.PositieOpDeKabel == 10)
                {
                    moveToStart = true;
                }
            }

            if (moveToStart)
            {
                Lijn lijn = _lijnen.Last.Value;
                lijn.PositieOpDeKabel = 0;
                _lijnen.RemoveLast();
                _lijnen.AddFirst(lijn);
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn lastLijn = _lijnen.Last.Value;
            if (lastLijn != null && lastLijn.PositieOpDeKabel == 9)
            {
                // Verwijder de lijn uit de list
                _lijnen.RemoveLast();
                return lastLijn;
            } else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return string.Join("|", _lijnen.Select(m => m.PositieOpDeKabel).ToArray());
        }
    }
}