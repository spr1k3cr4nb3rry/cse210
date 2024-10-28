using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Scripture
{
    public ScriptureReference ScriptureReference { get; }
    private List<Word> Words { get; }
    public string Text => string.Join(" ", Words.Select(w => w.Text));

    public Scripture(ScriptureReference scriptureReference, string text)
    {
        ScriptureReference = scriptureReference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(ScriptureReference);
        Console.WriteLine(string.Join(" ", Words));
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < count)
        {
            var unhiddenWords = Words.Where(word => !word.IsHidden).ToList();
            if (unhiddenWords.Count == 0) break;

            int index = random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            hiddenCount++;
        }
    }

    public bool AllWordsHidden() => Words.All(word => word.IsHidden);
}