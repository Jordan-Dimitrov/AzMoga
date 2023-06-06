using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    class Instructions : Screen
    {
        public Instructions(int left, int top) 
            : base(left, top)
        {
        }

        public override void Draw()
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
        }

        public override void Update()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    ScreenManager.CurrentState = ScreenState.MainMenu;
                    break;
                }
            }
        }
    }
}
