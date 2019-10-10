namespace Waterskibaan
{
    public class Waterskibaan
    {
        private LijnenVoorraad _lijnenVoorraad = new LijnenVoorraad();
        private Kabel _kabel = new Kabel();

        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                _lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }
        }

        public void VerplaatsKabel()
        {
            _kabel.VerschuifLijnen();
            _lijnenVoorraad.LijnToevoegenAanRij(_kabel.VerwijderLijnVanKabel());
        }

        public override string ToString()
        {
            return "De waterskibaan heeft " + _lijnenVoorraad + " op de kabel " + _kabel;
        }
    }
}