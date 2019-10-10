﻿using System.Collections.Generic;

namespace Waterskibaan
{
    public class WachterijStarten : Wachtrij
    {
        public const int MAX_LENGTE_RIJ = 20;

        protected override int GetLengte()
        {
            return MAX_LENGTE_RIJ;
        }

        public override string ToString()
        {
            return base.ToString() + "start wachtrij";
        }
    }
}