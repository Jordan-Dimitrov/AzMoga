using System;
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
            if (playerWon == 1)
            {
                endScreen = @"
               __________.__                               ____                         ._.
               \______   \  | _____  ___.__. ___________  /_   | __  _  ______   ____   | |
                |     ___/  | \__  \<   |  |/ __ \_  __ \  |   | \ \/ \/ /  _ \ /    \  | |
                |    |   |  |__/ __ \\___  \  ___/|  | \/  |   |  \     (  <_> )   |  \  \|
                |____|   |____(____  / ____|\___  >__|     |___|   \/\_/ \____/|___|  /  __
                                   \/\/         \/                                  \/   \/";
            }
            else if (playerWon == 2)
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
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (DisableButtons(key))
                {
                    continue;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    MainMenu();
                }
            }
        }
        public bool DisableButtons(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.UpArrow && keyInfo.Key != ConsoleKey.DownArrow && keyInfo.Key != ConsoleKey.Escape)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void MainMenu()
        {
            Console.SetCursorPosition(this.Left, this.Top);
            this.Position = 2;
            Console.WriteLine(this.GameName);
            int matrixHeight = this.GameName.Split('\n').Length;
            int centerLeft = this.Left + (this.GameName.Length / matrixHeight) / 2;
            Console.SetCursorPosition(centerLeft, this.Top + 10);
            Console.WriteLine("Start Game");
            Console.SetCursorPosition(centerLeft + 2, this.Top + 12);
            Console.WriteLine("Stats");
            Console.SetCursorPosition(centerLeft - 1, this.Top + 14);
            Console.WriteLine("Instructions");
            Console.SetCursorPosition(centerLeft, this.Top + 10);
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (DisableButtons(key))
                {
                    continue;
                }
                MenuPosition(key);
                if (this.Position == 0)
                {
                    Console.SetCursorPosition(centerLeft - 1, this.Top + 14);

                }
                else if (this.Position == 1)
                {
                    Console.SetCursorPosition(centerLeft + 2, this.Top + 12);

                }
                else if (this.Position == 2)
                {
                    Console.SetCursorPosition(centerLeft, this.Top + 10);
                }
            }
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
            Console.WriteLine("Press escape to exit");
            Console.WriteLine("When \"Start Game\" is pressed, enter the Width, then enter the Height of the field. Both of them should be 4x4 or more.");
            Console.WriteLine(" ");
            Console.WriteLine("Controls: ");
            Console.WriteLine(" ");
            Console.WriteLine("* When \"W\" is pressed the player makes a move Up.");
            Console.WriteLine("* When \"A\" is pressed the player makes a move Left.");
            Console.WriteLine("* When \"S\" is pressed the player makes a move Down.");
            Console.WriteLine("* When \"D\" is pressed the player makes a move Right.");
            Console.WriteLine("* When \"Q\" is pressed the player makes a move by the Upper-Left diagonal.");
            Console.WriteLine("* When \"E\" is pressed the player makes a move by the Upper-Right diagonal.");
            Console.WriteLine("* When \"Z\" is pressed the player makes a move by the Lower-Left diagonal.");
            Console.WriteLine("* When \"C\" is pressed the player makes a move by the Lower-Right diagonal.");
            Console.WriteLine(" ");
            Console.WriteLine("The winner is the player which has the highest score, when all moves have been depleated.");
            IsEscPressed();
        }
        public void MenuPosition(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (this.Position != 2)
                {
                    this.Position += 1;
                }
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (this.Position != 0)
                {
                    this.Position -= 1;
                }
            }
            if (key.Key == ConsoleKey.Enter)
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
                    Console.Clear();
                    EnterCoordinates();
                }
            }
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
                if (width<4&&height<4)
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
