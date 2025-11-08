using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private readonly List<Entry> _entries;

    // Public read-only view if needed
    public IReadOnlyList<Entry> Entries => _entries.AsReadOnly();

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry e)
    {
        if (e != null)
            _entries.Add(e);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        Console.WriteLine("---- Journal Entries ----");
        foreach (var e in _entries)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine("-------------------------");
        }
    }

    // Save to file (each line = Entry.ToFileString())
    public void SaveToFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
            throw new ArgumentException("Filename must not be empty.");

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var e in _entries)
            {
                writer.WriteLine(e.ToFileString());
            }
        }
    }

    // Load from file and replace current entries
    public void LoadFromFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
            throw new ArgumentException("Filename must not be empty.");

        if (!File.Exists(filename))
            throw new FileNotFoundException($"File not found: {filename}");

        string[] lines = File.ReadAllLines(filename);
        _entries.Clear();

        foreach (var line in lines)
        {
            var entry = Entry.FromFileString(line);
            if (entry != null)
                _entries.Add(entry);
            else
            {
                // skip malformed lines but continue
            }
        }
    }

    public void Clear()
    {
        _entries.Clear();
    }
}
