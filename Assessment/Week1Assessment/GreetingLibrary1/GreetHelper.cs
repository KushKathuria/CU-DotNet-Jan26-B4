using System;

namespace GreetingLibrary1
{
    public class GreetHelper
    {
        public static string GetGreeting(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Hello, Guest!";
            }
            else
            {
                return $"Hello, {name}!";
            }
        }
    }
}
