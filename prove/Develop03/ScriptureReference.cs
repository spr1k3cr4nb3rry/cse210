using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString() => StartVerse == EndVerse
        ? $"{Book} {Chapter}:{StartVerse}"
        : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
}