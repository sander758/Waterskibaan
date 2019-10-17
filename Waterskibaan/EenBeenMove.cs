namespace Waterskibaan
{
    public class EenBeenMove : IMove
    {
        public int Move()
        {
            return 10;
        }

        public override string ToString()
        {
            return "Een Been";
        }
    }
}