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
            _EndScreenTexts = new string[] 
            {
                 @"
               ________                          ._.
               \______ \ _______ _____  __  _  __| |
                |    |  \\_  __ \\__  \ \ \/ \/ /| |
                |    `   \|  | \/ / __ \_\     /  \|
               /_______  /|__|   (____  / \/\_/   __
                       \/             \/          \/",

                @"
               __________.__                               ____                         ._.
               \______   \  | _____  ___.__. ___________  /_   | __  _  ______   ____   | |
                |     ___/  | \__  \<   |  |/ __ \_  __ \  |   | \ \/ \/ /  _ \ /    \  | |
                |    |   |  |__/ __ \\___  \  ___/|  | \/  |   |  \     (  <_> )   |  \  \|
                |____|   |____(____  / ____|\___  >__|     |___|   \/\_/ \____/|___|  /  __
                                   \/\/         \/                                  \/   \/",

                @"
               __________.__                              ________                          ._.
               \______   \  | _____  ___.__. ___________  \_____  \  __  _  ______   ____   | |
                |     ___/  | \__  \<   |  |/ __ \_  __ \  /  ____/  \ \/ \/ /  _ \ /    \  | |
                |    |   |  |__/ __ \\___  \  ___/|  | \/ /       \   \     (  <_> )   |  \  \|
                |____|   |____(____  / ____|\___  >__|    \_______ \   \/\_/ \____/|___|  /  __
                                   \/\/         \/                \/                    \/   \/"
            };
        }

        public override void Draw()
        {
            string endScreenText = _EndScreenTexts[Globals.PlayerWon];
            Console.WriteLine(endScreenText);
            Console.SetCursorPosition(_Left, _Top);
            int matrixHeight = endScreenText.Split('\n').Length;
            string[] matrixLines = endScreenText.Split('\n');
            string centerLine = matrixLines[matrixHeight / 2];
            _CenterLeft = _Left + (centerLine.Length / 2);
            Console.SetCursorPosition(_CenterLeft, _Top + 10);
            Console.WriteLine("New Game");
        }

        public override void Update()
        {
            Console.SetCursorPosition(_CenterLeft, _Top + 10);
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (!Utils.IsUIKeyValid(key))
            {
                return;
            }

            if (key.Key == ConsoleKey.Enter)
            {
                ScreenManager.CurrentState = ScreenState.MainMenu;
            }
        }

        private int _CenterLeft = 0;
        private string[] _EndScreenTexts;
    }
}
