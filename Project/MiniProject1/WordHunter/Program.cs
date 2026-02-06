using System;
using System.Collections.Generic;

namespace WordHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Lives = 6;

            List<string> input = new List<string>() { "CODE", "ASTRONOMY", "SCALE","PICKACHU","LIBRARY","KEYBOARD","SOFTWARE","FRAMEWORK","ALGORITHM","POINTER" };
            Random random = new Random();
            string HiddenWord = input[random.Next(input.Count)];
            char[] Word = HiddenWord.ToCharArray();

            HashSet<char> Guessed = new HashSet<char>();

            char[] Display = new char[HiddenWord.Length];
            for (int i = 0; i < Display.Length; i++)
                Display[i] = '_';

            Console.WriteLine("Welcome To My Game");

            while (Lives > 0 && new string(Display) != new string(Word))
            {
                Console.WriteLine();
                Console.WriteLine("Word: " + string.Join(" ", Display));
                Console.WriteLine($"Lives Remaining: {Lives}");
                Console.WriteLine("Guessed: " + string.Join(", ", Guessed));

                Console.Write("Enter a letter: ");
                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Input cannot be empty or whitespace.");
                    continue;
                }

                if (userInput.Length != 1)
                {
                    Console.WriteLine("Please enter exactly one letter.");
                    continue;
                }

                char letter = char.ToUpper(userInput[0]);

                if (!char.IsLetter(letter))
                {
                    Console.WriteLine("Not a valid letter. Try again.");
                    continue;
                }

                if (Guessed.Contains(letter))
                {
                    Console.WriteLine("You already guessed that letter.");
                    continue;
                }

                Guessed.Add(letter);

                bool foundLetter = false;

                for (int i = 0; i < Word.Length; i++)
                {
                    if (Word[i] == letter)
                    {
                        Display[i] = letter;
                        foundLetter = true;
                    }
                }

                if (!foundLetter)
                {
                    Lives--;
                    Console.WriteLine("Wrong letter!");
                }
            }

            Console.WriteLine();

            if (new string(Display) == new string(Word))
            {
                Console.WriteLine($"You guessed the right word: {HiddenWord}");
            }
            else
            {
                Console.WriteLine($"You lose!! Better luck next time.\nThe right word was: {HiddenWord}");
            }
        }
    }
}
