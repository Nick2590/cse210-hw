using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    // Base class for all activities
    abstract class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Run()
        {
            StartMessage();
            PerformActivity();
            EndMessage();
        }

        private void StartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Starting: {_name}");
            Console.WriteLine(_description);
            Console.Write("Enter duration in seconds: ");
            while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
            {
                Console.Write("Please enter a positive integer for duration: ");
            }

            Console.WriteLine("Get ready to begin...");
            PauseWithSpinner(3);
        }

        protected void PauseWithSpinner(int seconds)
        {
            string[] spinner = { "/", "-", "\\", "|" };
            for (int i = 0; i < seconds * 4; i++)
            {
                Console.Write($"\r{spinner[i % spinner.Length]}");
                Thread.Sleep(250);
            }
            Console.WriteLine();
        }

        protected void PauseWithCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\r{i}   ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected int Duration => _duration;

        private void EndMessage()
        {
            Console.WriteLine("\nWell done!");
            PauseWithSpinner(2);
            Console.WriteLine($"You have completed the {_name} for {Duration} seconds.");
            PauseWithSpinner(3);
        }

        // Each derived class implements its own activity
        protected abstract void PerformActivity();
    }

    class BreathingActivity : Activity
    {
        public BreathingActivity() 
            : base("Breathing Activity", 
                   "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

        protected override void PerformActivity()
        {
            int elapsed = 0;
            while (elapsed < Duration)
            {
                Console.WriteLine("Breathe in...");
                PauseWithCountdown(4); // inhale
                elapsed += 4;
                if (elapsed >= Duration) break;

                Console.WriteLine("Breathe out...");
                PauseWithCountdown(6); // exhale
                elapsed += 6;
            }
        }
    }

    class ReflectionActivity : Activity
    {
        private List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
            : base("Reflection Activity",
                  "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
                  "This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

        protected override void PerformActivity()
        {
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine($"\n{prompt}");
            PauseWithSpinner(3);

            int elapsed = 0;
            while (elapsed < Duration)
            {
                string question = questions[rand.Next(questions.Count)];
                Console.WriteLine($"\n{question}");
                PauseWithSpinner(5);
                elapsed += 5;
            }
        }
    }

    class ListingActivity : Activity
    {
        private List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity",
                  "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

        protected override void PerformActivity()
        {
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine($"\n{prompt}");
            Console.WriteLine("You have 5 seconds to start thinking...");
            PauseWithCountdown(5);

            List<string> items = new List<string>();
            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                Console.Write("Enter item: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                    items.Add(input);
            }

            Console.WriteLine($"\nYou listed {items.Count} items!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        quit = true;
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                }

                activity.Run();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
