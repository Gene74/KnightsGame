using System.Drawing;

namespace KnightsGame
{
    internal class Board
    {
        /*
         * Konstanten
         */

        private const int DELAY_MS = 200;

        /*
         * Eigenschaften
         */

        public int Width { get; private set; } = 8;
        public int Height { get; private set; } = 8;

        public int[,] board;
        public List<Point> moves { get; private set; }

        private long counter = 0;

        /*
         * Konstruktor
         */

        public Board(int width = 8, int height = 8)
        {
            Width = width >= 3 ? width : 8;
            Height = height >= 3 ? height : 8;
            board = new int[Width, Height];
            moves = new List<Point>();
        }

        /*
         * Methoden
         */

        public bool IsValidMove(Point p)
        {
            return
                (p.X >= 0 && p.X < Width && p.Y >= 0 && p.Y < Height)
                &&
                board[p.X, p.Y] == 0;
        }

        public bool IsComplete() => moves.Count == (Width * Height);

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
