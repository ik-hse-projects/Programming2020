using System;
using System.Collections.Generic;

public partial class TestSystem
{
    private Dictionary<string, User> users = new Dictionary<string, User>();

    public void Add(string username)
    {
        if (!users.TryGetValue(username, out var user))
        {
            user = new User(username);
            users[username] = user;
        }

        if (user.Subscribed)
        {
            throw new ArgumentException("User already exists");
        }
        Notifications += user.SendMessage;
        user.Subscribed = true;
    }

    public void Remove(string username)
    {
        if (!users.TryGetValue(username, out var user))
        {
            throw new ArgumentException("User does not exist");
        }
        
        user.Subscribed = false;
        Notifications -= users[username].SendMessage;
    }
}