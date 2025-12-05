
using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points) : base(name, desc, points) { }

    public override int RecordEvent() => Points;

    public override string Serialize() => $"Eternal|{Name}|{Description}|{Points}";

    public override string GetDetails() => $"[∞] {Name} ({Description})";
}

