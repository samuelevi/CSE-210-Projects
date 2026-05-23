using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Reference scriptureReference = new Reference("John", 3, 16);

        string scriptureText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture scripture = new Scripture(scriptureReference, scriptureText);

        string userInput = "";

        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");
            userInput = Console.ReadLine() ?? ""; 

            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nProgram ended. Thank you for practicing!");
    }
}