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
        private int PlayerTurn;
        private Player _Player1, _Player2;
        private string[] _Forbidden;

        public Game(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            PlayerTurn = 0;
            _Player1 = new Player(0, 0, "P1", "V1");
            _Player2 = new Player(width - 1, height - 1, "P2", "V2");
            _Forbidden = new string[] { _Player1.Icon, _Player2.Icon, _Player1.VisitedIcon, _Player2.VisitedIcon };
        }

        public void Start()
        {
            RandomField field = new RandomField(this.Width, this.Height);
            field.GenerateAndRenderField();
            this.Field = field.field;
            Update();
        }

        public void Update()
        {
            while (true)
            {
                if (ValidMoveExits(PlayerTurn == 1 ? _Player1 : _Player2))
                {
                    string fileName = "scores.txt";
                    UI ui = new UI(0, 0);
                    Console.Clear();
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.WriteLine("Player1: " + _Player1.Score);
                        writer.WriteLine("Player2: " + _Player2.Score);
                    }

                    if (_Player1.Score > _Player2.Score)
                    {
                        ui.EndScreen(1);
                    }
                    else if (_Player2.Score > _Player1.Score)
                    {
                        ui.EndScreen(2);
                    }
                    else 
                    {
                        ui.EndScreen(3);
                    }
                    return;
                }

                ConsoleKeyInfo key = Console.ReadKey(true);
                if (IsKeyValid(key))
                {
                    continue;
                }

                if (Move(GetCurrentPlayer(), key))
                    DrawGame();
            }
        }

        public bool IsKeyValid(ConsoleKeyInfo keyInfo)
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

        private void DrawGame() 
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
            Console.WriteLine("Player 1: " + _Player1.Score);
            Console.WriteLine("Player 2: " + _Player2.Score);
        }

        public bool CheckIfOutside(int x, int y)
        {
            if (x >= 0 && x < this.Width && y >= 0 && y < this.Height)
            {
                return false;
            }
            return true;
        }

        private bool ValidMoveExits(Player player) 
        {
            bool validMoveExists = true;

            int[] dx = new[] { -1, 0, 1, 0, -1, 1, -1, 1 };
            int[] dy = new[] { 0, -1, 0, 1, -1, -1, 1, 1 };

            for (int dir = 0; dir < dx.Length; dir++)
            {
                int nx = player.X + dx[dir], ny = player.Y + dy[dir];
                if (!CheckIfOutside(nx, ny) && !_Forbidden.Contains(this.Field[ny, nx]))
                {
                    validMoveExists = false;
                    break;
                }
            }

            return validMoveExists;
        }

        private Player GetCurrentPlayer() 
        {
            return PlayerTurn % 2 == 0 ? _Player1 : _Player2;
        }

        public bool Move(Player player, ConsoleKeyInfo key)
        {
            int newX = player.X;
            int newY = player.Y;
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

            if (!CheckIfOutside(newX, newY) && !_Forbidden.Contains(this.Field[newY, newX]))
            {
                string value = this.Field[newY, newX];
                this.Field[player.Y, player.X] = player.VisitedIcon;
                this.Field[newY, newX] = player.Icon;
                player.X = newX;
                player.Y = newY;
                string operation = value[0].ToString();
                int num = int.Parse(value[1].ToString());
                GetCurrentPlayer().Score = ChangeScore(operation, num, GetCurrentPlayer().Score);
                PlayerTurn++;

                return true;
            }

            return false;
        }
        static int ChangeScore(string operation, int num, int score)
        {
            switch (operation)
            {
                case "x": return score * num;
                case "/": return score / num;
                case "-": return score - num;
                case "+": return score + num;
            }

            return 0;
        }
    }
}