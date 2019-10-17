using System.Collections.Generic;

namespace Waterskibaan
{
    public class Logger
    {
        private Kabel kabel;
        public List<Sporter> Sporters { get; set; }

        public Logger(Kabel kabel)
        {
            this.kabel = kabel;
        }

        public void OnNieuweBezoeker(NieuweBezoekerArgs args)
        {
            Sporters.Add(args.Sporter);
        }
    }
}