using System.Collections.Generic;

namespace Waterskibaan
{
    public class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (_lijnen.Count == 0 || _lijnen.First.Value.PositieOpKabel == 0)
            {
                return true;
            }

            return false;
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            //
        }

        public void VerschuifLijnen()
        {

        }

        public Lijn VerwijderLijnVanKabel()
        {
            return null;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}