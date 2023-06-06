using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    class EndScreen : Screen
    {
        public EndScreen(int left, int top) 
            : base(left, top)
        {
        }

        public override void Draw()
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
            centerLeft = _Left  / 2;
            Console.SetCursorPosition(centerLeft * 2 - 5, _Top + 10);
            Console.WriteLine("New Game");
            
        }

        public override void Update()
        {
            while (true)
            {
                Console.SetCursorPosition(centerLeft * 2 - 5, _Top + 10);
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (!IsKeyValid(key))
                {
                    continue;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    ScreenManager.CurrentState = ScreenState.MainMenu;
                }
            }
        }

        private int centerLeft = 0;
    }
}
