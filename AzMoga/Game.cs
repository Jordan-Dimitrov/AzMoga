using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    class Game
    {
        private int Width;
        private int Height;
        private string[,] Field;
        private int Player1X;
        private int Player1Y;
        private int Player2X;
        private int Player2Y;
        private int PlayerTurn;
        public Game(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Player1X = 0;
            this.Player1Y = 0;
            this.Player2X = width-1;
            this.Player2Y = height-1;
            this.PlayerTurn = 1;
        }
        public void Start()
        {
            RandomField field = new RandomField(this.Width, this.Height);
            field.GenerateAndRenderField();
            this.Field = field.field;
            Movement();
        }
        public bool DisabledKeys(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key != ConsoleKey.Q && keyInfo.Key != ConsoleKey.W && keyInfo.Key != ConsoleKey.E && keyInfo.Key != ConsoleKey.A && keyInfo.Key != ConsoleKey.S && keyInfo.Key != ConsoleKey.D && keyInfo.Key != ConsoleKey.Z && keyInfo.Key != ConsoleKey.C)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Movement()
        {
            if (PlayerTurn==1)
            {
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (DisabledKeys(key))
                    {
                        continue;
                    }

                }
            }
            else if (PlayerTurn==2)
            {

            }
        }
    }
}
