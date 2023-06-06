using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    class MainMenu : Screen
    {
        public MainMenu(int left, int top) 
            : base(left, top)
        {
            _GameName = @" 
             __  __       _   _  _______   _      _        
            |  \/  |     | | | ||__   __| (_)    | |       
            | \  / | __ _| |_| |__ | |_ __ _  ___| | _____ 
            | |\/| |/ _` | __| '_ \| | '__| |/ __| |/ / __|
            | |  | | (_| | |_| | | | | |  | | (__|   <\__ \
            |_|  |_|\__,_|\__|_| |_|_|_|  |_|\___|_|\_\___/";

            _Position = 2;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(_Left, _Top);
            _Position = 2;
            Console.WriteLine(_GameName);
            int matrixHeight = _GameName.Split('\n').Length;
            _CenterLeft = _Left + (_GameName.Length / matrixHeight) / 2;
            Console.SetCursorPosition(_CenterLeft, _Top + 10);
            Console.WriteLine("Start Game");
            Console.SetCursorPosition(_CenterLeft + 2, _Top + 12);
            Console.WriteLine("Stats");
            Console.SetCursorPosition(_CenterLeft - 1, _Top + 14);
            Console.WriteLine("Instructions");
            Console.SetCursorPosition(_CenterLeft, _Top + 10);
        }

        public override void Update()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (IsKeyValid(key))
                {
                    continue;
                }
                MenuPosition(key);
                if (_Position == 0)
                {
                    Console.SetCursorPosition(_CenterLeft - 1, _Top + 14);

                }
                else if (_Position == 1)
                {
                    Console.SetCursorPosition(_CenterLeft + 2, _Top + 12);

                }
                else if (_Position == 2)
                {
                    Console.SetCursorPosition(_CenterLeft, _Top + 10);
                }
            }
        }

        public void MenuPosition(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (_Position != 2)
                {
                    _Position += 1;
                }
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (_Position != 0)
                {
                    _Position -= 1;
                }
            }
            if (key.Key == ConsoleKey.Enter)
            {
                if (_Position == 0)
                {
                    Console.Clear();
                    ScreenManager.CurrentState = ScreenState.Instructions;
                }
                else if (_Position == 1)
                {
                    Console.Clear();
                    ScreenManager.CurrentState = ScreenState.Stats;
                }
                else if (_Position == 2)
                {
                    Console.Clear();
                    ScreenManager.CurrentState = ScreenState.GameSettings;
                }
            }
        }

        private int _Position;
        private string _GameName;
        private int _CenterLeft;
    }
}
