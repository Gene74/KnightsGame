using System.Drawing;

namespace KnightsGame
{
    static class KnightsGame
    {
        static void Main()
        {
            var board = new Board();
            var player = new PlayerAI(board);

            var startAt = new Point(0, 0);

            // let the ai continue from there
            if (player.Run(startAt))
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
