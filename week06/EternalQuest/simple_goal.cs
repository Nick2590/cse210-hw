
using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string desc, int points, bool done = false) : base(name, desc, points)
    {
        _isComplete = done;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        return 0;
    }

    public override string Serialize() => $"Simple|{Name}|{Description}|{Points}|{_isComplete}";

    public override string GetDetails() => _isComplete ? $"[X] {Name} ({Description})" : $"[ ] {Name} ({Description})";
}

