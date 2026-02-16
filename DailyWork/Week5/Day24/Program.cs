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
Hashtable table= new Hashtable();
            table.Add(101, "Alice");
            table.Add(102, "Bob");
            table.Add(103, "Charlie");
            table.Add(104, "Diana");

            if (!table.ContainsKey(105))
            {
                table[105] = "Edward";
            }
            else
            {
                Console.WriteLine($"{105} : {table[105]}");
            }

            string SampleName = (string)table[102];

            Console.WriteLine($"Name[102]:  {SampleName}");
            foreach(DictionaryEntry i in table)
            {
                Console.WriteLine($"Id: {i.Key}  Name: {i.Value}");
            }

            table.Remove(103);
            int tableCount=table.Count;
            Console.WriteLine($"Table count :{tableCount}");
                }

    }
}






