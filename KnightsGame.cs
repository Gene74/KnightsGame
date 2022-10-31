using System.Drawing;

namespace KnightsGame
{
    static class KnightsGame
    {
        static void Main()
        {
            // create the board -> default 8x8 fields
            var board = new Board();

            // create the player and pass the board
            var player = new PlayerAI(board);

            // define the field where we start
            var startAt = new Point(0, 0);

            // let the ai continue from there
            bool success = player.Run(startAt);

            // solution found?
            if (success)
            {
                board.PrintBoard(0, 2);
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Solution Found");
            }
            else 
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Solution NOT Found");
            }
        }
    }
}
