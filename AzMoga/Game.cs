using System;

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
            this.Player2X = width - 1;
            this.Player2Y = height - 1;
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
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (DisabledKeys(key))
                {
                    continue;
                }

                int prevPlayerX = (PlayerTurn == 1) ? Player1X : Player2X;
                int prevPlayerY = (PlayerTurn == 1) ? Player1Y : Player2Y;

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        if (prevPlayerY > 0)
                            prevPlayerY--;
                        break;
                    case ConsoleKey.A:
                        if (prevPlayerX > 0)
                            prevPlayerX--;
                        break;
                    case ConsoleKey.S:
                        if (prevPlayerY < Height - 1)
                            prevPlayerY++;
                        break;
                    case ConsoleKey.D:
                        if (prevPlayerX < Width - 1)
                            prevPlayerX++;
                        break;
                    case ConsoleKey.Q:
                        if (prevPlayerX > 0 && prevPlayerY > 0)
                        {
                            prevPlayerX--;
                            prevPlayerY--;
                        }
                        break;
                    case ConsoleKey.E:
                        if (prevPlayerX < Width - 1 && prevPlayerY > 0)
                        {
                            prevPlayerX++;
                            prevPlayerY--;
                        }
                        break;
                    case ConsoleKey.Z:
                        if (prevPlayerX > 0 && prevPlayerY < Height - 1)
                        {
                            prevPlayerX--;
                            prevPlayerY++;
                        }
                        break;
                    case ConsoleKey.C:
                        if (prevPlayerX < Width - 1 && prevPlayerY < Height - 1)
                        {
                            prevPlayerX++;
                            prevPlayerY++;
                        }
                        break;
                }

                if (PlayerTurn == 1)
                {
                    Player1X = prevPlayerX;
                    Player1Y = prevPlayerY;
                    PlayerTurn = 2;
                }
                else if (PlayerTurn == 2)
                {
                    Player2X = prevPlayerX;
                    Player2Y = prevPlayerY;
                    PlayerTurn = 1;
                }

                RenderField();
            }
        }

        public void RenderField()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == Player1X && y == Player1Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (x == Player2X && y == Player2Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(Field[y, x] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }

    
}
