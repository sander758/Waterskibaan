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
            TestOpdracht3();
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
    }
}
