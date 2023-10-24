using System;

namespace quatrecentvingtetun
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game(5, 5);
            game.Run();
            Console.WriteLine($"Score final : {game.Score()}");
        }
    }
}