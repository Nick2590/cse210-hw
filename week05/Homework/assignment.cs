using System;

public class Assignment
{
    // Protected so derived classes can access it
    protected string _studentName;
    protected string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to get a summary of the assignment
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Optional getter for student name if needed
    public string GetStudentName()
    {
        return _studentName;
    }
}
