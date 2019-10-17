using System;
using System.Drawing;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

//            TestOpdracht2();
//            TestOpdracht3();
//            TestOpdracht8();
//            TestOpdracht10();
            TestOpdracht11();
        }

        private static void TestOpdracht2()
        {
            Kabel kabel = new Kabel();
            Console.WriteLine("Kabel: " + kabel);
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            Console.WriteLine("Kabel: " + kabel);
            kabel.NeemLijnInGebruik(new Lijn());
            Console.WriteLine("Kabel: " + kabel);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            Console.WriteLine("Kabel: " + kabel);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            Console.WriteLine("Kabel: " + kabel);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            Console.WriteLine("Kabel: " + kabel);
            kabel.VerschuifLijnen();
            Console.WriteLine("Kabel: " + kabel);
            kabel.VerwijderLijnVanKabel();
            Console.WriteLine("Kabel: " + kabel);
        }

        private static void TestOpdracht3()
        {
            LijnenVoorraad voorraad = new LijnenVoorraad();
            voorraad.LijnToevoegenAanRij(new Lijn());
            Console.WriteLine(voorraad);
            voorraad.LijnToevoegenAanRij(new Lijn());
            Console.WriteLine(voorraad);
            voorraad.LijnToevoegenAanRij(new Lijn());
            Console.WriteLine(voorraad);
            voorraad.VerwijderEersteLijn();
            Console.WriteLine(voorraad);
        }

        private static void TestOpdracht8()
        {
            Waterskibaan baan = new Waterskibaan();
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
            sporter.Skies = new Skies();
            sporter.Zwemvest = new Zwemvest();
            try
            {
                baan.SporterStart(sporter);
                baan.VerplaatsKabel();
                baan.SporterStart(new Sporter(MoveCollection.GetWillekeurigeMoves()));
                baan.VerplaatsKabel();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void TestOpdracht10()
        {
            InstructieGroep groep = new InstructieGroep();
            for (int i = 0; i < 6; i++)
            {
                groep.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            } 
            Console.WriteLine(groep);
        }

        private static void TestOpdracht11()
        {
            Game game = new Game();
            game.Initialize();
        }
    }
}
