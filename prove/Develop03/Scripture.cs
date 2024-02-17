
// this class which represent the scrpture itself.
//it will include properties that store the scripture refernce ("Reference") and a list of "ScriptureWord" objects("words")
//The class provides methods to initialize the scripture with a reference and text, hide a random word, display the scripture, and check if all words are hidden.
using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private List<ScriptureWord> words = new List<ScriptureWord>();
    public ScriptureReference Reference { get; private set; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        words.AddRange(text.Split().Select(word => new ScriptureWord(word)));
    }

    public void HideRandomWord()
    {
        var wordsToHide = words.Where(word => !word.Hidden).ToList();
        if (wordsToHide.Any())
        {
            var wordToHide = wordsToHide[new Random().Next(wordsToHide.Count)];
            wordToHide.Hide();
        }
    }

    public void Display()
    {
        Console.WriteLine(Reference.ToString() + "\n");
        foreach (var word in words)
        {
            Console.Write(word.ToString() + " ");
        }
        Console.WriteLine("\n");
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.Hidden);
    }
}
