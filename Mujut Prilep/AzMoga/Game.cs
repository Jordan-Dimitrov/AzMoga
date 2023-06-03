using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace AzMoga
{
    class Game
    {
        private int Width;
        private int Height;
        private string[,] Field;
        private int Player1X;
        private int Player1Score;
        private int Player2Score;
        private int Player1Y;
        private int Player2X;
        private int Player2Y;
        private int PlayerTurn;
        private string Player1;
        private string Player2;
        private string VisitedByPlayer1;
        private string VisitedByPlayer2;

        public Game(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Player1X = 0;
            this.Player1Y = 0;
            this.Player2X = width - 1;
            this.Player2Y = height - 1;
            this.PlayerTurn = 1;
            this.Player1 = "P1";
            this.Player2 = "P2";
            this.Player1Score = 0;
            this.Player2Score = 0;
            this.VisitedByPlayer1 = "V1";
            this.VisitedByPlayer2 = "V2";
        }

        public void Start()
        {
            RandomField field = new RandomField(this.Width, this.Height);
            field.GenerateAndRenderField();
            this.Field = field.field;
            Movement();
        }

        public void Update()
        {
            Console.Clear();
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    Console.Write(this.Field[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Player 1: " + this.Player1Score);
            Console.WriteLine("Player 2: " + this.Player2Score);
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
                if (PlayerTurn == 1)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (DisabledKeys(key))
                    {
                        continue;
                    }
                    Move(ref this.Player1X, ref this.Player1Y, key, this.Player1, this.VisitedByPlayer1);
                }
                else if (PlayerTurn == 2)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (DisabledKeys(key))
                    {
                        continue;
                    }
                    Move(ref this.Player2X, ref this.Player2Y, key, this.Player2, this.VisitedByPlayer2);
                }
            }
        }


        public bool CheckIfOutside(int x, int y)
        {
            if (x >= 0 && x < this.Width && y >= 0 && y < this.Height)
            {
                return false;
            }
            return true;
        }
        public void Move(ref int playerX, ref int playerY, ConsoleKeyInfo key, string player, string playerVisited)
        {
            string[] forbidden = { this.Player1, this.Player2, this.VisitedByPlayer1, this.VisitedByPlayer2 };
            int newX = playerX;
            int newY = playerY;
            var noValidMovesLeft = true;

            var dx = new[] { -1, 0, 1, 0, -1, 1, -1, 1 };
            var dy = new[] { 0, -1, 0, 1, -1, -1, 1, 1 };

            for (int dir = 0; dir < dx.Length; dir++)
            {
                int nx = playerX + dx[dir], ny = playerY + dy[dir];
                if (!CheckIfOutside(nx, ny) && !forbidden.Contains(this.Field[ny, nx]))
                {
                    noValidMovesLeft = false;
                    break;
                }
            }

            if (noValidMovesLeft)
            {
                string fileName = "scores.txt";
                UI ui = new UI(0, 0);
                if (this.Player1Score > this.Player2Score)
                {
                    Console.Clear();
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.WriteLine("Player1: " + this.Player1Score);
                        writer.WriteLine("Player2: " + this.Player2Score);
                    }

                    ui.EndScreen(1);
                }
                else if (this.Player2Score > this.Player1Score)
                {
                    Console.Clear();
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.WriteLine("Player1: " + this.Player1Score);
                        writer.WriteLine("Player2: " + this.Player2Score);
                    }

                    ui.EndScreen(2);
                }
                if (this.PlayerTurn == 1)
                {
                    Console.Clear();
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.WriteLine("Player1: " + this.Player1Score);
                        writer.WriteLine("Player2: " + this.Player2Score);
                    }

                    ui.EndScreen(2);
                }
                else if (this.PlayerTurn == 2)
                {
                    Console.Clear();
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.WriteLine("Player1: " + this.Player1Score);
                        writer.WriteLine("Player2: " + this.Player2Score);
                    }

                    ui.EndScreen(1);
                }
                return;
            }

            if (key.Key == ConsoleKey.Q)
            {
                newX--;
                newY--;
            }
            else if (key.Key == ConsoleKey.W)
            {
                newY--;
            }
            else if (key.Key == ConsoleKey.E)
            {
                newX++;
                newY--;
            }
            else if (key.Key == ConsoleKey.A)
            {
                newX--;
            }
            else if (key.Key == ConsoleKey.S)
            {
                newY++;
            }
            else if (key.Key == ConsoleKey.D)
            {
                newX++;
            }
            else if (key.Key == ConsoleKey.Z)
            {
                newX--;
                newY++;
            }
            else if (key.Key == ConsoleKey.C)
            {
                newX++;
                newY++;
            }

            if (!CheckIfOutside(newX, newY) && !forbidden.Contains(this.Field[newY, newX]))
            {
                string value = this.Field[newY, newX];
                this.Field[playerY, playerX] = playerVisited;
                this.Field[newY, newX] = player;
                playerX = newX;
                playerY = newY;
                string operation = value[0].ToString();
                int num = int.Parse(value[1].ToString());
                if (this.PlayerTurn == 1)
                {
                    this.Player1Score = ChangeScore(operation, num, this.Player1Score);
                    this.PlayerTurn = 2;
                }
                else if (this.PlayerTurn == 2)
                {
                    this.Player2Score = ChangeScore(operation, num, this.Player2Score);
                    this.PlayerTurn = 1;
                }
                Update();
            }
        }
        static int ChangeScore(string operation, int num, int score)
        {
            if (operation == "x")
            {
                score *= num;
            }
            else if (operation == "/")
            {
                score /= num;
            }
            else if (operation == "-")
            {
                score -= num;
            }
            else if (operation == "+")
            {
                score += num;
            }
            return score;
        }
    }
}