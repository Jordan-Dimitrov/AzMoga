using System;
using System.IO;
namespace AzMoga
{
    class UI
    {
        
        private int Left;
        private int Top;
        public UI(int left, int top)
        {
            
        }
        public void EndScreen(int playerWon)
        {
            
        }
        
        public void MainMenu()
        {
            
        }
        public void IsEscPressed()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    MainMenu();
                }
            }
        }
        public void GameStats()
        {
            Console.WriteLine("Press escape to exit");
            string filePath = @"scores.txt";
            string fileContents = File.ReadAllText(filePath);
            Console.WriteLine(fileContents);
            IsEscPressed();
        }
        public void Instructions()
        {
        }
        
        public void EnterCoordinates()
        {
            while (true)
            {
                Console.SetCursorPosition(this.Left, this.Top);
                Console.WriteLine("Enter width: ");
                Console.SetCursorPosition(this.Left + 12, this.Top);
                string widthInput = Console.ReadLine();
                int width;
                if (!int.TryParse(widthInput, out width))
                {
                    Console.Clear();
                    continue;
                }
                Console.SetCursorPosition(this.Left, this.Top + 2);
                Console.WriteLine("Enter height: ");
                Console.SetCursorPosition(this.Left + 13, this.Top + 2);
                string heightInput = Console.ReadLine();
                int height;
                if (!int.TryParse(heightInput, out height))
                {
                    Console.Clear();
                    continue;
                }
                if (width < 4 || height < 4 || width > 20 || height > 20)
                {
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                Game game = new Game(width, height);
                game.Start();
                break;
            }
        }
    }
}
