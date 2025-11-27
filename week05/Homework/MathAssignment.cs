using System;

public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // Constructor calls base class constructor for studentName and topic
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Method to display homework list
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
