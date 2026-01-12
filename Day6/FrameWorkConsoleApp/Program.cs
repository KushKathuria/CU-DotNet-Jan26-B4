using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreetingLibrary1;
namespace FrameWorkConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("hello");

            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            string message = GreetHelper.GetGreeting(name);

            Console.WriteLine(message);

            Console.ReadLine();
        }
    }
}
