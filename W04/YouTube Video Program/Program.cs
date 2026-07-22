using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all the videos
        List<Video> videos = new List<Video>();

        // --- Video 1 ---
        Video video1 = new Video("C# Basics for Beginners", "Tech Wizard", 600);
        video1.AddComment(new Comment("JohnDoe", "This was very helpful, thanks!"));
        video1.AddComment(new Comment("Alice99", "Could you make a video on Classes next?"));
        video1.AddComment(new Comment("CodeNewbie", "I finally understand abstraction."));
        videos.Add(video1);

        // --- Video 2 ---
        Video video2 = new Video("Top 10 Programming Languages in 2026", "Code World", 450);
        video2.AddComment(new Comment("DevMaster", "C# is definitely top 3 for me."));
        video2.AddComment(new Comment("PythonFan", "Where is Python?! Oh wait, there it is."));
        video2.AddComment(new Comment("StudentBob", "Great list, really informative."));
        videos.Add(video2);

        // --- Video 3 ---
        Video video3 = new Video("How to build a PC", "Hardware Guy", 1200);
        video3.AddComment(new Comment("Gamer123", "I just built my first PC using this guide."));
        video3.AddComment(new Comment("TechNoob", "What happens if I don't use thermal paste?"));
        video3.AddComment(new Comment("PCBuilder", "Great cable management at the end."));
        videos.Add(video3);

        // --- Display Information ---
        Console.WriteLine("--- YouTube Video Tracker ---\n");
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
