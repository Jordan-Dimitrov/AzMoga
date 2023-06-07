using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    class SettingsScreen : Screen
    {
        public SettingsScreen(int left, int top) : base(left, top)
        {
        }

        public override void Draw()
        {
            Console.SetCursorPosition(_Left, _Top);
            Console.WriteLine("Enter width: ");
            Console.SetCursorPosition(_Left + 12, _Top);
            string widthInput = Console.ReadLine();
            int width;

            bool isParsingSuccessful = true;
            if (!int.TryParse(widthInput, out width))
            {
                Console.Clear();
                isParsingSuccessful = false;
            }
            Console.SetCursorPosition(_Left, _Top + 2);
            Console.WriteLine("Enter height: ");
            Console.SetCursorPosition(_Left + 13, _Top + 2);
            string heightInput = Console.ReadLine();
            int height;
            if (!int.TryParse(heightInput, out height))
            {
                Console.Clear();
                isParsingSuccessful = false;
            }
            if (width < 4 || height < 4 || width > 20 || height > 20)
            {
                Console.Clear();
                isParsingSuccessful = false;
            }

            if (isParsingSuccessful) 
            {
                Globals.Width = width;
                Globals.Height = height;
                ScreenManager.CurrentState = ScreenState.Game;
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
