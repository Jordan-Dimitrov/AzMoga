using System;
<<<<<<< HEAD
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

=======
using System.Text;
using System.Threading;
>>>>>>> 6404cb953f12e403399d63a469380b218e2a1a71
namespace AzMoga
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            string input = Console.ReadLine();
            int x = int.Parse(input[0].ToString());
            int y = int.Parse(input[2].ToString());

            RandomField field = new RandomField(y, x);
            field.GenerateAndRenderField();
=======
            UI ui = new UI(1,1);
            ui.EndScreen(1);
>>>>>>> 6404cb953f12e403399d63a469380b218e2a1a71
        }
    }
}
