using System;

public class RandomField
{
    private int width;
    private int height;
    private string[,] field;
    private Random random;

    public RandomField(int width, int height)
    {
        this.width = width;
        this.height = height;
        field = new string[height, width];
        random = new Random();
    }

    public void GenerateAndRenderField()
    {
        string[] operations = { "-", "x", "/", "+" };

        Console.SetCursorPosition(0, 0);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if ((x == 0 && y == 0) || (x == width - 1 && y == height - 1))
                {
                    field[y, x] = "0";
                }
                else
                {
                    int number = random.Next(10);
                    string operation = operations[random.Next(operations.Length)];
                    field[y, x] = operation + number.ToString();
                }

                Console.Write(field[y, x] + " ");
            }
            Console.WriteLine();
        }
    }
}
