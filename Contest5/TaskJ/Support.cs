using System.Collections.Generic;
using System.Linq;

public class Support
{
    private readonly List<Task> tasks = new List<Task>();

    public IEnumerable<Task> Tasks => tasks;

    public int OpenTask(string text)
    {
        var id = tasks.Count + 1;
        tasks.Add(new Task(id, text));
        return id;
    }

    public void CloseTask(int id, string answer)
    {
        var task = tasks[id - 1];
        task.Answer = answer;
        task.IsResolved = true;
    }

    public List<Task> GetAllUnresolvedTasks()
    {
        return tasks.Where(task => !task.IsResolved).ToList();
    }

    public void CloseAllUnresolvedTasksWithDefaultAnswer(string answer)
    {
        foreach (var task in GetAllUnresolvedTasks())
        {
            CloseTask(task.Id, answer);
        }
    }

    public string GetTaskInfo(int id)
    {
        return tasks[id - 1].ToString();
    }
}