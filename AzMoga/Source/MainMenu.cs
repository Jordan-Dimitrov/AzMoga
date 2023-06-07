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
            _Position = 0;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(_Left, _Top);
            Console.WriteLine(Globals.GameName);
            int matrixHeight = Globals.GameName.Split('\n').Length;
            _CenterLeft = _Left + (Globals.GameName.Length / matrixHeight) / 2;
            for (int i = 0; i < _SettingNames.Length; i++)
            {
                Console.SetCursorPosition(_CenterLeft + _SettingsXOffset[i], _Top + (10 + (i * 2)));
                Console.WriteLine(_SettingNames[i]);
            }

            Console.SetCursorPosition(_CenterLeft + _SettingsXOffset[_Position], _Top + (10 + (_Position * 2)));
        }

        public override void Update()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (!IsKeyValid(key))
                {
                    continue;
                }
                if (IsOptionChosen(key))
                    break;

                Console.SetCursorPosition(_CenterLeft + _SettingsXOffset[_Position], _Top + (10 + (_Position * 2)));
            }
        }

        public bool IsOptionChosen(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                _Position--;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                _Position++;
            }

            _Position = _Position % 3;
            if (_Position < 0)
            {
                _Position = 3 + _Position;
            }

            if (key.Key == ConsoleKey.Enter)
            {
                if (_Position == 0)
                {
                    ScreenManager.CurrentState = ScreenState.GameSettings;
                    return true;
                }
                else if (_Position == 1)
                {
                    ScreenManager.CurrentState = ScreenState.Stats;
                    return true;
                }
                else if (_Position == 2)
                {
                    ScreenManager.CurrentState = ScreenState.Instructions;
                    return true;
                }
            }

            return false;
        }

        private int _Position;
        private string _GameName;
        private int _CenterLeft;
        private int[] _SettingsXOffset = { 0, 2, -1 };
        private string[] _SettingNames = { "Start Game", "Stats", "Instructions" };
    }
}
