using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string book, int chapter, int verse, string text)
    {
        _reference = new Reference(book, chapter, verse);
        _words = new List<Word>(Array.ConvertAll(text.Split(' '), word => new Word(word)));
    }

    public Scripture(string book, int chapter, int startVerse, int endVerse, string text)
    {
        _reference = new Reference(book, chapter, startVerse, endVerse);
        _words = new List<Word>(Array.ConvertAll(text.Split(' '), word => new Word(word)));
    }

    public void DisplayScripture()
    {
        Console.WriteLine($"{_reference}: {_words.ConvertToString()}");
    }

    public bool HideWord()
    {
        List<Word> visibleWords = _words.GetVisibleWords();
        if (visibleWords.Count < 2)
            return false;

        Random random = new Random();
        int randomIndex1, randomIndex2;

        do
        {
            randomIndex1 = random.Next(visibleWords.Count);
            randomIndex2 = random.Next(visibleWords.Count);
        } while (randomIndex1 == randomIndex2);

        visibleWords[randomIndex1].Hide();
        visibleWords[randomIndex2].Hide();
        return true;
    }
}

static class Extensions
{
    public static string ConvertToString(this List<Word> words)
    {
        return string.Join(" ", words.ConvertAll(word => word.DisplayWord()));
    }

    public static List<Word> GetVisibleWords(this List<Word> words)
    {
        return words.FindAll(word => !word.IsHidden());
    }
}