

using System;
using System.Collections.Generic;
using System.IO;


public class EternalQuest
{
private List<Goal> _goals = new List<Goal>();
private int _score = 0;


public void Run()
{
bool running = true;
while (running)
{
Console.Clear();
Console.WriteLine($"*** Eternal Quest *** Score: {_score}");
Console.WriteLine("1. Create New Goal");
Console.WriteLine("2. List Goals");
Console.WriteLine("3. Record Event");
Console.WriteLine("4. Save Goals");
Console.WriteLine("5. Load Goals");
Console.WriteLine("6. Quit");
Console.Write("Select an option: ");


switch (Console.ReadLine())
{
case "1": CreateGoal(); break;
case "2": ListGoals(); break;
case "3": RecordEvent(); break;
case "4": SaveGoals(); break;
case "5": LoadGoals(); break;
case "6": running = false; break;
default: Console.WriteLine("Invalid option."); break;
}
if (running)
{
Console.WriteLine("Press Enter to continue...");
Console.ReadLine();
}
}
}


private void CreateGoal()
{
	// TODO: Implement CreateGoal
}

private void ListGoals()
{
	// TODO: Implement ListGoals
}

private void RecordEvent()
{
	// TODO: Implement RecordEvent
}

private void SaveGoals()
{
	// TODO: Implement SaveGoals
}

private void LoadGoals()
{
	// TODO: Implement LoadGoals
}
}