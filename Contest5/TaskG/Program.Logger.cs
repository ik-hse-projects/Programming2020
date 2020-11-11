using System;
using System.Collections.Generic;
using System.IO;

public partial class Program
{
    public static bool ParseCommandsCount(string input, out int count)
    {
        return int.TryParse(input, out count) && count > 0;
    }

    public class Logger
    {
        private readonly List<string> logs = new List<string>();
        private static readonly Logger logger = new Logger();

        private void HandleCommandNonStatic(string command)
        {
            if (command.StartsWith("AddLog <"))
            {
                var log = command.Substring(8, command.Length - 9);
                logs.Add(log);
            }
            else switch (command)
            {
                case "DeleteLastLog" when logs.Count == 0:
                case "WriteAllLogs" when logs.Count == 0:
                    File.AppendAllLines("logs.log", new[] {"No active logs"});
                    break;
                case "DeleteLastLog":
                    logs.RemoveAt(logs.Count - 1);
                    break;
                case "WriteAllLogs":
                    File.AppendAllLines("logs.log", logs);
                    logs.Clear();
                    break;
                default:
                    throw new Exception("Invalid command.");
            }
        }

        public static void HandleCommand(string command)
        {
            logger.HandleCommandNonStatic(command);
        }
    }

}