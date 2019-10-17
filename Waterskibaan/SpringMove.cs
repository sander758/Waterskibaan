namespace Waterskibaan
{
    public class SpringMove : IMove
    {
        public int Move()
        {
            return 5;
        }

        public override string ToString()
        {
            return "Spring";
        }
    }
}