using System;
using System.Collections.Generic;

public class User
{
    private string username;
    private List<string> notifications = new List<string>();
    
    public User(string username)
    {
        this.username = username;
    }

    public bool Subscribed { get; set; }

    public void SendMessage(string text)
    {
        if (!Subscribed)
        {
            return;
        }
        
        Console.WriteLine($"-{username}-");

        if (notifications.Count != 0)
        {
            Console.WriteLine("Received notifications:");
            foreach (var notification in notifications)
            {
                Console.WriteLine(notification);
            }
        }
        
        Console.WriteLine($"New notification: {text}");
        notifications.Add(text);
    }
}