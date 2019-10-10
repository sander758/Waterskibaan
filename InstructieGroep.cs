using System.Collections.Generic;

namespace Waterskibaan
{
    public class InstructieGroep : Wachtrij
    {
        public const int MAX_LENGTE_RIJ = 5;

        protected override int GetLengte()
        {
            return MAX_LENGTE_RIJ;
        }

        public override string ToString()
        {
            return base.ToString() + "instructie groep";
        }
    }
}