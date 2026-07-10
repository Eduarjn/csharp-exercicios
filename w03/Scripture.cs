using System;
using System.Collections.Generic;

namespace ScriptureMemorizer;

// Represents a full scripture: its reference and its list of words.
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] tokens = text.Split(' ');
        foreach (string token in tokens)
        {
            if (token != "")
            {
                _words.Add(new Word(token));
            }
        }
    }

    // Hides up to "count" words. Only picks words that are still visible.
    public void HideRandomWords(int count)
    {
        for (int i = 0; i < count; i++)
        {
            List<Word> visibleWords = new List<Word>();
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    visibleWords.Add(word);
                }
            }

            if (visibleWords.Count == 0)
            {
                break;
            }

            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public int GetPercentHidden()
    {
        if (_words.Count == 0)
        {
            return 100;
        }

        int hiddenCount = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                hiddenCount = hiddenCount + 1;
            }
        }
        return (int)Math.Round(100.0 * hiddenCount / _words.Count);
    }

    public string GetDisplayText()
    {
        string wordsText = "";
        foreach (Word word in _words)
        {
            wordsText = wordsText + word.GetDisplayText() + " ";
        }
        return _reference.GetDisplayText() + "\n" + wordsText.Trim();
    }
}