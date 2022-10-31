using System.Drawing;

namespace KnightsGame
{
    internal class Board
    {
        /*
         * Constants
         */

        /// <summary>
        /// if the board is printed "live", this is the delay between every move.
        /// </summary>
        private const int DELAY_MS = 200;

        /*
         * Properties
         */

        // Width and height of the board
        public int Width { get; private set; } = 8;
        public int Height { get; private set; } = 8;

        /// <summary>
        /// to collect all the movements with the number of the move in the fields
        /// </summary>
        public int[,] board;

        /// <summary>
        /// will count the current moves: addition and subtraction
        /// </summary>
        public List<Point> moves { get; private set; }

        /// <summary>
        /// counts all moves that had been made in total
        /// </summary>
        private long counter = 0;

        /*
         * Constructor
         */

        public Board(int width = 8, int height = 8)
        {
            Width = width >= 3 ? width : 8;
            Height = height >= 3 ? height : 8;
            board = new int[Width, Height];
            moves = new List<Point>();
        }

        /*
         * Methods
         */

        /// <summary>
        /// Checks if the point p is on the board and if that field is still available
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsValidMove(Point p)
        {
            return
                (p.X >= 0 && p.X < Width && p.Y >= 0 && p.Y < Height)
                &&
                board[p.X, p.Y] == 0;
        }

        /// <summary>
        /// Checks if the board has been completed
        /// </summary>
        /// <returns></returns>
        public bool IsComplete() => moves.Count == (Width * Height);

        /// <summary>
        /// Checks a move if it would be valid and does it or not
        /// </summary>
        /// <param name="p"></param>
        /// <param name="show">print the board?</param>
        /// <returns></returns>
        public bool Move(Point p, bool show = false)
        {
            if (!IsValidMove(p)) return false;
            moves.Add(p);
            board[p.X, p.Y] = moves.Count();
            counter++;
            if (show)
            {
                PrintBoard();
                Thread.Sleep(DELAY_MS);
            }
            return true;
        }

        /// <summary>
        /// Undo the last move
        /// </summary>
        /// <param name="show">print the board?</param>
        /// <returns></returns>
        public bool Undo(bool show = false)
        {
            if (moves.Count == 0) return false;
            var p = moves[moves.Count - 1];
            board[p.X, p.Y] = 0;
            moves.RemoveAt(moves.Count - 1);
            if (show)
            {
                PrintBoard();
                Thread.Sleep(DELAY_MS);
            }
            return true;
        }


        /// <summary>
        /// Prints the board with all the current moves + total moves up to now.
        /// </summary>
        /// <param name="offsetLeft"></param>
        /// <param name="offsetTop"></param>
        public void PrintBoard(int offsetLeft = 0, int offsetTop = 2)
        {
            const string LINE_A = "+--+--+--+--+--+--+--+--+";
            const string LINE_B = "|  |  |  |  |  |  |  |  |";
            int row = 0;

            Console.Clear();
            Console.Write("#Moves: " + counter);

            for (int y = 0; y < Height; y++)
            {
                Console.SetCursorPosition(offsetLeft, offsetTop + row);
                Console.Write(LINE_A);
                row++;
                Console.SetCursorPosition(offsetLeft, offsetTop + row);
                Console.Write(LINE_B);
                for (int x = 0; x < Height; x++)
                {
                    if (board[x,y] > 0)
                    {
                        Console.SetCursorPosition(offsetLeft + (x * 3) + 1, offsetTop + row);
                        Console.Write("{0,2:00}", board[x, y]);
                    }
                }
                row++;
            }
            Console.SetCursorPosition(offsetLeft, offsetTop + row);
            Console.Write(LINE_A);
        }



    }
}
