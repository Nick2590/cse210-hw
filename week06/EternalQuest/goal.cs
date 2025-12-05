
using System;

public abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }

    public Goal(string name, string desc, int points)
    {
        Name = name;
        Description = desc;
        Points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetDetails();
    public abstract string Serialize();

    public static Goal Deserialize(string line)
    {
        string[] parts = line.Split('|');
        switch (parts[0])
        {
            case "Simple": return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "Eternal": return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "Checklist": return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
        }
        throw new Exception("Unknown goal type.");
    }
}

