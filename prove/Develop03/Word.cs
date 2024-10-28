using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide() => IsHidden = true;
    public override string ToString() => IsHidden ? "____" : Text;
}