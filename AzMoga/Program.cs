using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace AzMoga
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int x = int.Parse(input[0].ToString());
            int y = int.Parse(input[2].ToString());

            RandomField field = new RandomField(y, x);
            field.GenerateAndRenderField();
        }
    }
}
