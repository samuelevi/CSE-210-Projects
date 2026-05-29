using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to C#", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
        video1.AddComment(new Comment("Charlie", "Can you explain abstraction more?"));
        videos.Add(video1);

        Video video4 = new Video("Abstraction in OOP", "TechTalks", 750);
        video4.AddComment(new Comment("Judy", "Exactly what I needed for my assignment."));
        video4.AddComment(new Comment("Mallory", "Could you do a video on inheritance?"));
        video4.AddComment(new Comment("Niaj", "Well explained."));
        videos.Add(video4);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
