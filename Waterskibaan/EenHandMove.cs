namespace Waterskibaan
{
    public class EenHandMove : IMove
    {
        public int Move()
        {
            return 8;
        }

        public override string ToString()
        {
            return "Een Hand";
        }
    }
}