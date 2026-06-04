using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class LogEntry
{
    public string ActivityName { get; set; }
    public int Duration { get; set; }
    public DateTime Timestamp { get; set; }
}

public class ActivityLogger
{
    private string _filename = "activity_log.json";
    private List<LogEntry> _logs;

    public ActivityLogger()
    {
        _logs = LoadLogs();
    }

    private List<LogEntry> LoadLogs()
    {
        if (File.Exists(_filename))
        {
            string jsonString = File.ReadAllText(_filename);
            return JsonSerializer.Deserialize<List<LogEntry>>(jsonString) ?? new List<LogEntry>();
        }
        return new List<LogEntry>();
    }

    public void LogActivity(string name, int duration)
    {
        _logs.Add(new LogEntry
        {
            ActivityName = name,
            Duration = duration,
            Timestamp = DateTime.Now
        });
        SaveLogs();
    }

    private void SaveLogs()
    {
        string jsonString = JsonSerializer.Serialize(_logs, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filename, jsonString);
    }

    public void DisplaySummary()
    {
        Console.Clear();
        if (_logs.Count == 0)
        {
            Console.WriteLine("No activities recorded yet.");
            return;
        }

        Dictionary<string, int> counts = new Dictionary<string, int>();
        int totalTime = 0;

        foreach (var entry in _logs)
        {
            if (counts.ContainsKey(entry.ActivityName))
                counts[entry.ActivityName]++;
            else
                counts[entry.ActivityName] = 1;

            totalTime += entry.Duration;
        }

        Console.WriteLine("--- Activity Summary ---");
        foreach (var pair in counts)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value} times");
        }
        Console.WriteLine($"Total time spent: {totalTime} seconds");
        Console.WriteLine("------------------------");
    }
}
