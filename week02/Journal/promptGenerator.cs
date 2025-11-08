using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts;
    private readonly Random _random;

    public PromptGenerator()
    {
        _random = new Random();

        // At least five prompts. Add / modify as you like.
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today and why?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn today?",
            // A few extras to keep variety
            "What made me smile today?",
            "What am I grateful for right now?"
        };
    }

    // Return a random prompt
    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0) return "Write something about your day.";
        int i = _random.Next(_prompts.Count);
        return _prompts[i];
    }

    // Allow adding prompts (useful for extra-credit/extension)
    public void AddPrompt(string prompt)
    {
        if (!string.IsNullOrWhiteSpace(prompt))
            _prompts.Add(prompt.Trim());
    }

    // Optional: list prompts
    public IEnumerable<string> GetAllPrompts()
    {
        return _prompts.AsReadOnly();
    }
}
