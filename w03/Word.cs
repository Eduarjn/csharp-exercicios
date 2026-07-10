namespace ScriptureMemorizer;

// Represents a single word in a scripture.
// A Word is responsible for storing its own text and its own shown/hidden
// state. No other class is allowed to reach in and change that state directly.
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the word if visible, or a row of underscores matching its
    // length if it is currently hidden.
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string hidden = "";
            foreach (char letter in _text)
            {
                if (char.IsLetter(letter))
                {
                    hidden = hidden + "_";
                }
                else
                {
                    hidden = hidden + letter;
                }
            }
            return hidden;
        }

        return _text;
    }
}
