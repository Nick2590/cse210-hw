using System;

public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor calls base class constructor for studentName and topic
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to display writing information
    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }
}
