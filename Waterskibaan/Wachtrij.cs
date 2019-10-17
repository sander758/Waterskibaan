using System.Collections.Generic;
using System.Linq;

namespace Waterskibaan
{
    public abstract class Wachtrij : IWachtrij
    {
        protected Queue<Sporter> sporters = new Queue<Sporter>();

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (sporters.Count < GetLengte())
            {
                sporters.Enqueue(sporter);
            }
        }

        public List<Sporter> GetAlleSporters()
        {
            return sporters.ToList();
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> verlatenSporters = new List<Sporter>();

            for (int i = 0; i < aantal; i++)
            {
                if (sporters.Count > 0 && sporters.Peek() != null)
                {
                    verlatenSporters.Add(sporters.Dequeue());
                }
            }

            return verlatenSporters;
        }

        public int AantalInWachtrij()
        {
            return sporters.Count;
        }

        public abstract int GetLengte();

        public override string ToString()
        {
            return "Er staan " + sporters.Count + "/" + GetLengte() + " sporters in de ";
        }
    }
}