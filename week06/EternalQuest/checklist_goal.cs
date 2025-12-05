
using System;

public class ChecklistGoal : Goal
{
    private int _completed;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus, int completed = 0) : base(name, desc, points)
    {
        _completed = completed;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _completed++;
        if (_completed == _target)
            return Points + _bonus;
        return Points;
    }

    public override string Serialize() => $"Checklist|{Name}|{Description}|{Points}|{_target}|{_bonus}|{_completed}";

    public override string GetDetails() => $"[{_completed}/{_target}] {Name} ({Description})";
}
