using System;
using System.Collections.Generic;

namespace AzMoga
{
    public class Game
    {
        private int Width;
        private int Height;
        private string[,] Field;
        private int Player1X;
        private int Player1Y;
        private int Player2X;
        private int Player2Y;
        private int PlayerTurn;
        private List<(int, int)> visitedCells;

        public Game(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Player1X = 0;
            this.Player1Y = 0;
            this.Player2X = width - 1;
            this.Player2Y = height - 1;
            this.PlayerTurn = 1;
            this.visitedCells = new List<(int, int)>();
            visitedCells.Add((Player1X, Player1Y));
            visitedCells.Add((Player2X, Player2Y));
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
                        if (prevPlayerY > 0 && !visitedCells.Contains((prevPlayerX, prevPlayerY - 1)))
                            prevPlayerY--;
                        break;
                    case ConsoleKey.A:
                        if (prevPlayerX > 0 && !visitedCells.Contains((prevPlayerX - 1, prevPlayerY)))
                            prevPlayerX--;
                        break;
                    case ConsoleKey.S:
                        if (prevPlayerY < Height - 1 && !visitedCells.Contains((prevPlayerX, prevPlayerY + 1)))
                            prevPlayerY++;
                        break;
                    case ConsoleKey.D:
                        if (prevPlayerX < Width - 1 && !visitedCells.Contains((prevPlayerX + 1, prevPlayerY)))
                            prevPlayerX++;
                        break;
                    case ConsoleKey.Q:
                        if (prevPlayerX > 0 && prevPlayerY > 0 && !visitedCells.Contains((prevPlayerX - 1, prevPlayerY - 1)))
                        {
                            prevPlayerX--;
                            prevPlayerY--;
                        }
                        break;
                    case ConsoleKey.E:
                        if (prevPlayerX < Width - 1 && prevPlayerY > 0 && !visitedCells.Contains((prevPlayerX + 1, prevPlayerY - 1)))
                        {
                            prevPlayerX++;
                            prevPlayerY--;
                        }
                        break;
                    case ConsoleKey.Z:
                        if (prevPlayerX > 0 && prevPlayerY < Height - 1 && !visitedCells.Contains((prevPlayerX - 1, prevPlayerY + 1)))
                        {
                            prevPlayerX--;
                            prevPlayerY++;
                        }
                        break;
                    case ConsoleKey.C:
                        if (prevPlayerX < Width - 1 && prevPlayerY < Height - 1 && !visitedCells.Contains((prevPlayerX + 1, prevPlayerY + 1)))
                        {
                            prevPlayerX++;
                            prevPlayerY++;
                        }
                        break;
                }

                if (PlayerTurn == 1)
                {
                    if (prevPlayerX == Player1X && prevPlayerY == Player1Y)
                        continue; // Player 1 is blocked, skip the turn
                    visitedCells.Add((Player1X, Player1Y));
                    Player1X = prevPlayerX;
                    Player1Y = prevPlayerY;
                    PlayerTurn = 2;
                }
                else if (PlayerTurn == 2)
                {
                    if (prevPlayerX == Player2X && prevPlayerY == Player2Y)
                        continue; // Player 2 is blocked, skip the turn
                    visitedCells.Add((Player2X, Player2Y));
                    Player2X = prevPlayerX;
                    Player2Y = prevPlayerY;
                    PlayerTurn = 1;
                }

                RenderField();

                // Check if any player is blocked
                bool player1Blocked = IsPlayerBlocked(Player1X, Player1Y);
                bool player2Blocked = IsPlayerBlocked(Player2X, Player2Y);

                if (player1Blocked && player2Blocked)
                {
                    // Both players are blocked, display scores and declare a tie
                    Console.WriteLine("Player 1 Score: " + GetPlayerScore(1));
                    Console.WriteLine("Player 2 Score: " + GetPlayerScore(2));
                    Console.WriteLine("It's a tie!");
                    break;
                }
                else if (player1Blocked)
                {
                    // Player 1 is blocked, display scores and declare Player 2 as the winner
                    Console.WriteLine("Player 1 Score: " + GetPlayerScore(1));
                    Console.WriteLine("Player 2 Score: " + GetPlayerScore(2));
                    Console.WriteLine("Player 2 wins!");
                    break;
                }
                else if (player2Blocked)
                {
                    // Player 2 is blocked, display scores and declare Player 1 as the winner
                    Console.WriteLine("Player 1 Score: " + GetPlayerScore(1));
                    Console.WriteLine("Player 2 Score: " + GetPlayerScore(2));
                    Console.WriteLine("Player 1 wins!");
                    break;
                }
            }
        }

        private bool IsPlayerBlocked(int x, int y)
        {
            bool upBlocked = y > 0 && visitedCells.Contains((x, y - 1));
            bool downBlocked = y < Height - 1 && visitedCells.Contains((x, y + 1));
            bool leftBlocked = x > 0 && visitedCells.Contains((x - 1, y));
            bool rightBlocked = x < Width - 1 && visitedCells.Contains((x + 1, y));
            bool upperLeftBlocked = x > 0 && y > 0 && visitedCells.Contains((x - 1, y - 1));
            bool upperRightBlocked = x < Width - 1 && y > 0 && visitedCells.Contains((x + 1, y - 1));
            bool lowerLeftBlocked = x > 0 && y < Height - 1 && visitedCells.Contains((x - 1, y + 1));
            bool lowerRightBlocked = x < Width - 1 && y < Height - 1 && visitedCells.Contains((x + 1, y + 1));

            return upBlocked && downBlocked && leftBlocked && rightBlocked &&
                   upperLeftBlocked && upperRightBlocked && lowerLeftBlocked && lowerRightBlocked;
        }
        public int GetPlayerScore(int player)
        {
            int x = (player == 1) ? Player1X : Player2X;
            int y = (player == 1) ? Player1Y : Player2Y;

            string cellValue = Field[y, x];
            string operation = cellValue.Substring(0, 1);
            int number = int.Parse(cellValue.Substring(1));

            int score = 0;

            switch (operation)
            {
                case "-":
                    score -= number;
                    break;
                case "x":
                    score *= number;
                    break;
                case "/":
                    score /= number;
                    break;
                case "+":
                    score += number;
                    break;
            }

            return score;
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
                    else if (visitedCells.Contains((x, y)) && (x != Player1X || y != Player1Y) && (x != Player2X || y != Player2Y))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(Field[y, x] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}