using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AzMoga
{
    class GameStats : Screen
    {

        public GameStats(int left, int top) 
            : base(left, top)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Press escape to exit");
            string filePath = @"scores.txt";
            string fileContents = File.ReadAllText(filePath);
            Console.WriteLine(fileContents);
        }

        public override void Update()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                ScreenManager.CurrentState = ScreenState.MainMenu;
            }
        }
    }
}
