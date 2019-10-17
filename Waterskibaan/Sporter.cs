﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Waterskibaan
{
    public class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public int AfgelegdeRondjes { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMove> Moves { get; set; }
        public int BehaaldePunten { get; set; }
        public IMove HuidigeMove { get; set; }

        public Sporter(List<IMove> moves)
        {
            Moves = moves;
            Random r = new Random();
            KledingKleur = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
        }
    }
}