using System;

public class Entry
{
    // Properties for the entry
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; } // stored as string per assignment

    // Separator used for file storage (choose something unlikely to appear in free text)
    private const string Separator = "~|~";

    public Entry() { }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Format for saving to file
    public string ToFileString()
    {
        // We do a minimal escaping: replace occurrences of Separator in text with a safe version.
        // (This keeps logic simple while avoiding breaking the file format.)
        string safePrompt = Prompt?.Replace(Separator, " ");
        string safeResponse = Response?.Replace(Separator, " ");
        string safeDate = Date?.Replace(Separator, " ");

        return $"{safePrompt}{Separator}{safeResponse}{Separator}{safeDate}";
    }

    // Parse a line from file into an Entry. Returns null if parsing fails.
    public static Entry FromFileString(string line)
    {
        if (string.IsNullOrEmpty(line)) return null;
        string[] parts = line.Split(new string[] { Separator }, StringSplitOptions.None);
        if (parts.Length != 3) return null;

        return new Entry(parts[0], parts[1], parts[2]);
    }

    // For display to console
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}
