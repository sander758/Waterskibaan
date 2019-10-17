using System;
using System.Collections.Generic;

namespace Waterskibaan
{
    public static class MoveCollection
    {
        public static List<IMove> GetWillekeurigeMoves()
        {
            List<IMove> moves = new List<IMove>();

            Random r = new Random();
            int amountOfMoves = r.Next(15);

            for (int i = 0; i < amountOfMoves; i++)
            {
                switch (r.Next(3)) 
                {
                    case 0:
                        moves.Add(new EenBeenMove());
                        break;
                    case 1:
                        moves.Add(new EenHandMove());
                        break;
                    case 2:
                        moves.Add(new SpringMove());
                        break;
                    case 3:
                        moves.Add(new OmdraaiMove());
                        break;
                }
            }

            return moves;
        }
    }
}