
using System;

class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1) Write a new entry");
            Console.WriteLine("2) Display the journal");
            Console.WriteLine("3) Save the journal to a file");
            Console.WriteLine("4) Load the journal from a file (will replace current journal)");
            Console.WriteLine("5) Add a custom prompt (optional)");
            Console.WriteLine("6) List built-in prompts (optional)");
            Console.WriteLine("0) Quit");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine()?.Trim();

            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, prompts);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    AddCustomPrompt(prompts);
                    break;
                case "6":
                    ListPrompts(prompts);
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Unknown option. Please enter a number from the menu.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal, PromptGenerator prompts)
    {
        string prompt = prompts.GetRandomPrompt();
        Console.WriteLine("Prompt:");
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("Write your response. Press Enter when finished:");
        string response = Console.ReadLine() ?? "";

        string dateText = DateTime.Now.ToShortDateString();
        var entry = new Entry(prompt, response, dateText);
        journal.AddEntry(entry);

        Console.WriteLine("Entry added.");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save to (e.g. journal.txt): ");
        string filename = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        try
        {
            journal.SaveToFile(filename);
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load from (e.g. journal.txt): ");
        string filename = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        try
        {
            journal.LoadFromFile(filename);
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    static void AddCustomPrompt(PromptGenerator prompts)
    {
        Console.Write("Enter a new prompt to add: ");
        string p = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(p))
        {
            Console.WriteLine("Prompt was empty; nothing added.");
            return;
        }
        prompts.AddPrompt(p);
        Console.WriteLine("Prompt added.");
    }

    static void ListPrompts(PromptGenerator prompts)
    {
        Console.WriteLine("Available prompts:");
        int i = 1;
        foreach (var p in prompts.GetAllPrompts())
        {
            Console.WriteLine($"{i++}) {p}");
        }
    }
}
