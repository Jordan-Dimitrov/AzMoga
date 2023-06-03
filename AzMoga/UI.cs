using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace AzMoga
{
    class UI
    {
        private string GameName;
        private string GameEnd;
        private int Left;
        private int Top;
        private int Position;
        public UI(int left, int top)
        {
            this.GameName = @" 
             __  __       _   _  _______   _      _        
            |  \/  |     | | | ||__   __| (_)    | |       
            | \  / | __ _| |_| |__ | |_ __ _  ___| | _____ 
            | |\/| |/ _` | __| '_ \| | '__| |/ __| |/ / __|
            | |  | | (_| | |_| | | | | |  | | (__|   <\__ \
            |_|  |_|\__,_|\__|_| |_|_|_|  |_|\___|_|\_\___/";

            this.Left = left;
            this.Top = top;
            this.Position = 2;
        }
        public void EndScreen(int playerWon)
        {
            string endScreen = "";
            if (playerWon==1)
            {
                endScreen = @"
               __________.__                               ____                         ._.
               \______   \  | _____  ___.__. ___________  /_   | __  _  ______   ____   | |
                |     ___/  | \__  \<   |  |/ __ \_  __ \  |   | \ \/ \/ /  _ \ /    \  | |
                |    |   |  |__/ __ \\___  \  ___/|  | \/  |   |  \     (  <_> )   |  \  \|
                |____|   |____(____  / ____|\___  >__|     |___|   \/\_/ \____/|___|  /  __
                                   \/\/         \/                                  \/   \/";
            }
            else if (playerWon==2)
            {
                endScreen = @"
               __________.__                              ________                          ._.
               \______   \  | _____  ___.__. ___________  \_____  \  __  _  ______   ____   | |
                |     ___/  | \__  \<   |  |/ __ \_  __ \  /  ____/  \ \/ \/ /  _ \ /    \  | |
                |    |   |  |__/ __ \\___  \  ___/|  | \/ /       \   \     (  <_> )   |  \  \|
                |____|   |____(____  / ____|\___  >__|    \_______ \   \/\_/ \____/|___|  /  __
                                   \/\/         \/                \/                    \/   \/";
            }
            Console.WriteLine(endScreen);
            Console.SetCursorPosition(this.Left, this.Top);
            int matrixHeight = endScreen.Split('\n').Length;
            int centerLeft = this.Left + (this.GameName.Length / matrixHeight) / 2;
            Console.SetCursorPosition(centerLeft * 2 - 5, this.Top + 10);
            Console.WriteLine("New Game");
            while (true)
            {
                Console.SetCursorPosition(centerLeft * 2 - 5, this.Top + 10);
                ConsoleKey key = Console.ReadKey().Key;
                if (key==ConsoleKey.Enter)
                {
                    Console.Clear();
                    MainMenu();
                }
            }
        }
        public void MainMenu()
        {
            Console.SetCursorPosition(this.Left, this.Top);
            this.Position = 2;
            Console.WriteLine(1);
            Console.WriteLine(this.GameName);
            int matrixHeight = this.GameName.Split('\n').Length;
            int centerLeft = this.Left + (this.GameName.Length / matrixHeight) / 2;
            Console.SetCursorPosition(centerLeft, this.Top+10);
            Console.WriteLine("Start Game");
            Console.SetCursorPosition(centerLeft+2, this.Top + 12);
            Console.WriteLine("Stats");
            Console.SetCursorPosition(centerLeft-1, this.Top + 14);
            Console.WriteLine("Instructions");
            Console.SetCursorPosition(centerLeft, this.Top + 10);
            while (true)
            {
                MenuPosition();
                if (this.Position == 0)
                {
                    Console.SetCursorPosition(centerLeft-1, this.Top + 14);
                    
                }
                else if (this.Position == 1)
                {
                    Console.SetCursorPosition(centerLeft + 2, this.Top + 12);
                   
                }
                else if (this.Position==2)
                {
                    Console.SetCursorPosition(centerLeft, this.Top + 10);
                }
            }
        }
        public void IsEscPressed()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key==ConsoleKey.Escape)
                {
                    Console.Clear();
                    MainMenu();
                }
            }
        }
        public void GameStats()
        {
            string filePath = @"scores.txt";
            string fileContents = File.ReadAllText(filePath);
            Console.WriteLine(fileContents);
            IsEscPressed();
        }
        public void Instructions()
        {
            Console.WriteLine(1);
            IsEscPressed();
        }
        public void MenuPosition()
        {
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (this.Position != 2)
                {
                    this.Position += 1;
                }
            }
            if (key == ConsoleKey.DownArrow)
            {
                if (this.Position != 0)
                {
                    this.Position -= 1;
                }
            }
            if (key == ConsoleKey.Enter)
            {
                if (this.Position == 0)
                {
                    Console.Clear();
                    Instructions();
                }
                else if (this.Position == 1)
                {
                    Console.Clear();
                    GameStats();
                }
                else if (this.Position == 2)
                {
                    
                }
            }
        }
    }
}
