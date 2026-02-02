using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Clasworkk
{
    class AgeException : Exception
    {
        public AgeException(string message) : base(message) { }
    }
    class NameException : Exception
    {
        public NameException(string message) : base(message) { }

    }
    class Innerexception : Exception
    {
        public Innerexception(string message) : base(message) { }
    }


    internal class TryCatch
    {
        static void Main(string[] args)
        {
            try
            {
                int num1, num2;
                Console.WriteLine("Enter num1");
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter num2");
                num2 = int.Parse(Console.ReadLine());
                decimal ans = (decimal)num1 / num2;
                Console.WriteLine(ans);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Division Complete");
            }






            Console.WriteLine("\n----------------------------------");
            try
            {

                Console.WriteLine("Enter a string of Numbers");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine(input);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
            finally
            {
                Console.WriteLine("String to Int Complete");
            }




            Console.WriteLine("\n----------------------------------");
            try
            {
                int[] arr = new int[5];
                Console.WriteLine("Enter Index to get Element");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine(arr[index]);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
            finally
            {
                Console.WriteLine("Array index fetched");
            }
            Console.WriteLine("\n----------------------------------");





            int age;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Age");
                    age = int.Parse(Console.ReadLine());
                    if (age < 18 || age > 60)
                    {
                        throw new AgeException("Enter a Valid Age");
                    }
                    Console.WriteLine($"age :{age}");
                    break;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("\n----------------------------------");






            string Name;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Name");
                    Name = Console.ReadLine();

                    //Regex r = new Regex(Name, @"^[A-Z]{1}");
                    if (string.IsNullOrWhiteSpace(Name) || !Regex.IsMatch(Name, @"^[A-Z]{1}[a-z]{2,}"))
                    {
                        throw new NameException("Enter a Valid Name or Enter in Proper Syntax");
                    }
                    Console.WriteLine(Name);
                    break;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message); ;
                } 
            }




            try
            {
                try
                {
                    throw new AgeException("Invalid age exception occurred");
                }
                catch (AgeException ex)
                {
                    throw new Exception("Student validation failed", ex);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Message: " + e.Message);
                Console.WriteLine("StackTrace: " + e.StackTrace);
                Console.WriteLine("InnerException: " + e.InnerException.Message);
            }

        }
    }
}
