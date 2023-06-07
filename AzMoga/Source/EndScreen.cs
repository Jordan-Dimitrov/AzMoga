using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    class EndScreen : Screen
    {
        public EndScreen() 
            : base(0, 0)
        {
        }

        public override void Draw()
        {
            string endScreen = "";
            if (Globals.PlayerWon == 1)
            {
                endScreen = @"
               __________.__                               ____                         ._.
               \______   \  | _____  ___.__. ___________  /_   | __  _  ______   ____   | |
                |     ___/  | \__  \<   |  |/ __ \_  __ \  |   | \ \/ \/ /  _ \ /    \  | |
                |    |   |  |__/ __ \\___  \  ___/|  | \/  |   |  \     (  <_> )   |  \  \|
                |____|   |____(____  / ____|\___  >__|     |___|   \/\_/ \____/|___|  /  __
                                   \/\/         \/                                  \/   \/";
            }
            else if (Globals.PlayerWon == 2)
            {
                endScreen = @"
               __________.__                              ________                          ._.
               \______   \  | _____  ___.__. ___________  \_____  \  __  _  ______   ____   | |
                |     ___/  | \__  \<   |  |/ __ \_  __ \  /  ____/  \ \/ \/ /  _ \ /    \  | |
                |    |   |  |__/ __ \\___  \  ___/|  | \/ /       \   \     (  <_> )   |  \  \|
                |____|   |____(____  / ____|\___  >__|    \_______ \   \/\_/ \____/|___|  /  __
                                   \/\/         \/                \/                    \/   \/";
            }
            else
            {
                endScreen = @"
              ________                          ._.
              \______ \ _______ _____  __  _  __| |
               |    |  \\_  __ \\__  \ \ \/ \/ /| |
               |    `   \|  | \/ / __ \_\     /  \|
              /_______  /|__|   (____  / \/\_/   __
                      \/             \/          \/";
            }
            Console.WriteLine(endScreen);
            Console.SetCursorPosition(_Left, _Top);
            int matrixHeight = endScreen.Split('\n').Length;
            string[] matrixLines = endScreen.Split('\n');
            string centerLine = matrixLines[matrixHeight / 2];
            string newGame = "New Game";
            //int len = centerLine.Length / 2;
            centerLeft = _Left + ((centerLine.Length / 2) - (newGame.Length / 2));
            Console.SetCursorPosition(centerLeft, _Top + 10);
            Console.WriteLine("New Game");
        }

        public override void Update()
        {
            Console.SetCursorPosition(centerLeft, _Top + 10);
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (!IsKeyValid(key))
            {
                return;
            }

            if (key.Key == ConsoleKey.Enter)
            {
                ScreenManager.CurrentState = ScreenState.MainMenu;
            }
        }

        private int centerLeft = 0;
    }
}
