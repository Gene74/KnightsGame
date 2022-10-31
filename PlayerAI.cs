using System.Drawing;

namespace KnightsGame
{
    internal class PlayerAI
    {
        /*
         * Properties
         */

        /// <summary>
        /// Link to the board
        /// </summary>
        private Board board;

        /*
         * Constructor
         */

        public PlayerAI(Board board)
        {
            this.board = board;
        }

        /*
         * Methods
         */

        /// <summary>
        /// Recursive algorithm
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Calculates the next position
        /// </summary>
        /// <param name="oldPos"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private Point calcNextPosition(Point oldPos, int pos)
        {
            var newPos = new Point(oldPos.X, oldPos.Y);

            switch (pos)
            {
                case 1: // 1 o'clock
                    newPos.X++;
                    newPos.Y -= 2;
                    break;

                case 2: // 2 o'clock
                    newPos.X += 2;
                    newPos.Y--;
                    break;

                case 3: // 4 o'clock
                    newPos.X += 2;
                    newPos.Y++;
                    break;

                case 4: // 5 o'clock
                    newPos.X++;
                    newPos.Y += 2;
                    break;

                case 5: // 7 o'clock
                    newPos.X--;
                    newPos.Y += 2;
                    break;

                case 6: // 8 o'clock
                    newPos.X -= 2;
                    newPos.Y++;
                    break;

                case 7: // 10 o'clock
                    newPos.X -= 2;
                    newPos.Y--;
                    break;

                case 8: // 11 o'clock
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
