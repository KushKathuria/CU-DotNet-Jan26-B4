using System.Threading.Channels;

namespace Classworkk
{

    internal class JournalReflection
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\Journal.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {

                Console.WriteLine("Enter Data");
                string data = Console.ReadLine();
                sw.WriteLine(data);

            }

            Console.WriteLine("--------------Reflection--------------\n");
            using (StreamReader sr = new StreamReader(path))
            {
                string Line;
                while ((Line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(Line);
                }
            }
        }
    }
}
//C:\Users\KUSH\source\repos\SolutionFolder\SolutionFolder\Clasworkk\file1.text