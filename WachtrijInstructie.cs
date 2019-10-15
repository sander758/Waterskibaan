using System;
using System.Collections.Generic;

namespace Waterskibaan
{
    public class WachtrijInstructie : Wachtrij
    {
        public const int MAX_LENGTE_RIJ = 100;

        public void OnNieuweBezoeker(NieuweBezoekerArgs args)
        {
            Console.WriteLine("Nieuwe bezoeker in instructie wachtrij");
            SporterNeemPlaatsInRij(args.Sporter);
        }

        public override int GetLengte()
        {
            return MAX_LENGTE_RIJ;
        }

        public override string ToString()
        {
            return base.ToString() + "instructie wachtrij";
        }
    }
}