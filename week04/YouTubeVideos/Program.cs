using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("Intro to C#", "TechTutor", 600);
        Video video2 = new Video("Best Coding Practices", "CodeMaster", 450);
        Video video3 = new Video("Debugging Tips", "DevPro", 520);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Bob", "Loved how simple it was explained."));
        video1.AddComment(new Comment("Charlie", "Can you do one on classes?"));

        // Add comments to video2
        video2.AddComment(new Comment("Diana", "Great tips!"));
        video2.AddComment(new Comment("Evan", "I’ll use this in my next project."));
        video2.AddComment(new Comment("Frank", "Can you share the sample code?"));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "Debugging is always hard!"));
        video3.AddComment(new Comment("Hank", "Super useful strategies."));
        video3.AddComment(new Comment("Ivy", "Thanks for sharing!"));

        // List of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display all video info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}
