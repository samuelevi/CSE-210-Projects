using System;
using System.Collections.Generic;
using System.Linq; 

public class Scripture
{
    private Reference _reference;
    private List<Word> _words; 

    
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        foreach (string wordText in text.Split(" "))
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> unhiddenWords = _words.Where(word => !word.IsHidden()).ToList();

        if (unhiddenWords.Count == 0)
        {
            return;
        }

        for (int i = 0; i < numberToHide; i++)
        {
            if (unhiddenWords.Count == 0)
            {
                break; 
            }
            
            int index = random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}