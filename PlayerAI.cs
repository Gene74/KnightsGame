using System.Drawing;

namespace KnightsGame
{
    internal class PlayerAI
    {
        /*
         * Eigenschaften
         */

        private Board board;

        /*
         * Konstruktor
         */

        public PlayerAI(Board board)
        {
            this.board = board;
        }

        /*
         * Methoden
         */

        public bool Run(Point p)
        {
            if (!board.Move(p)) return false;
            if (board.IsComplete()) return true;
            int pos = 1;
            bool searching = true;
            do
            {
                var nextPos = calcNextPosition(p, pos);
                if (!Run(nextPos))
                {
                    if (pos < 8)
                    {
                        pos++;
                        continue;
                    }
                    else
                    {
                        board.Undo();
                        return false;
                    }
                }
                else
                {
                    searching = false;
                }
            } while (searching);
            return true;
        }

        public Point calcNextPosition(Point oldPos, int pos)
        {
            var newPos = new Point(oldPos.X, oldPos.Y);

            switch (pos)
            {
                case 1: // 1uhr
                    newPos.X++;
                    newPos.Y -= 2;
                    break;

                case 2: // 2uhr
                    newPos.X += 2;
                    newPos.Y--;
                    break;

                case 3: // 4uhr
                    newPos.X += 2;
                    newPos.Y++;
                    break;

                case 4: // 5uhr
                    newPos.X++;
                    newPos.Y += 2;
                    break;

                case 5: // 7uhr
                    newPos.X--;
                    newPos.Y += 2;
                    break;

                case 6: // 8uhr
                    newPos.X -= 2;
                    newPos.Y++;
                    break;

                case 7: // 10uhr
                    newPos.X -= 2;
                    newPos.Y--;
                    break;

                case 8: // 11uhr
                    newPos.X--;
                    newPos.Y += 2;
                    break;

                default:
                    break;
            }

            return newPos;
        }



    }
}
