using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ClassLibrary1;
namespace Clasworkk
{
    
    
    internal class Program
    {
        static void Main(string[] args)
        {

            string Pin = string.Empty;
            Console.WriteLine("Enter 4 Digit Pin");
            while (true)
            {
var input=Console.ReadKey(true);
                char input1 =input.KeyChar;
                if (char.IsDigit(input1))
                {
                    Pin += input1;
                    Console.Write("*");
                }
                if (input.Key == ConsoleKey.Backspace) {
                    if (Pin.Length > 0)
                    {
                        string NewPin = string.Empty;
                        for (int i = 0; i < Pin.Length-1; i++) {
                            NewPin += Pin[i];
                        }
                        Pin = NewPin;
                            Console.Write("\b \b");
                    }
                }
                if (input.Key == ConsoleKey.Enter &&(Pin.Length==4)) { break; }

            }
                    Console.WriteLine();
            Console.WriteLine(Pin);
        
        
        
        }

    }
}



//



