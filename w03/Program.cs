using System;

namespace ScriptureMemorizer;

// ============================================================================
// W03 Project: Scripture Memorizer
//
// EXTRAS (creativity - beyond the core requirements):
// 1. The program keeps a LIBRARY of several scriptures and picks one at
//    RANDOM each time it runs (ScriptureLibrary class).
// 2. When hiding words, it only picks words that are still visible, so every
//    Enter hides NEW words.
// 3. A "% hidden" progress line shows how close you are to full recall.
// ============================================================================

public class Program
{
    public static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();

        library.AddScripture(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));

        library.AddScripture(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));

        library.AddScripture(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me."));

        Scripture scripture = library.GetRandomScripture();

        bool userQuit = false;
        while (!scripture.IsCompletelyHidden() && !userQuit)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Progress: " + scripture.GetPercentHidden() + "% hidden");
            Console.WriteLine();
            Console.Write("Press ENTER to hide words, or type 'quit' to end: ");

            string input = Console.ReadLine();
            if (input != null && input.Trim().ToLower() == "quit")
            {
                userQuit = true;
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }

        if (!userQuit)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("All words are hidden. Great job!");
        }
    }
}