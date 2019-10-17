namespace Waterskibaan
{
    public class OmdraaiMove : IMove
    {
        public int Move()
        {
            return 12;
        }

        public override string ToString()
        {
            return "Omdraaien";
        }
    }
}