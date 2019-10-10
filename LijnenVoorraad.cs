using System.Collections.Generic;

namespace Waterskibaan
{
    public class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen = new Queue<Lijn>();

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }

        public Lijn VerwijderEersteLijn()
        {
            return _lijnen.Dequeue();
        }

        public int GetAantalLijnen()
        {
            return _lijnen.Count;
        }

        public override string ToString()
        {
            return _lijnen.Count + " lijnen op voorraad";
        }
    }
}