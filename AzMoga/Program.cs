using System;

namespace AzMoga
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI(1, 1);
            ui.MainMenu();
            int y = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            Game game = new Game(y, x);
            game.Start();
        }
    }
}
