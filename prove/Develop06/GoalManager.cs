using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goalList;
    private int _currentScore;

    public GoalManager()
    {
        _goalList = new List<Goal>();
        _currentScore = 0;
    }

    public void CreateGoal(string type, string name, string description, int points, int target = 0)
    {
        Goal newGoal;
        switch (type)
        {
            case "SimpleGoal":
                newGoal = new SimpleGoal { Name = name, Description = description, Points = points };
                break;
            case "EternalGoal":
                newGoal = new EternalGoal { Name = name, Description = description, Points = points };
                break;
            case "ChecklistGoal":
                newGoal = new ChecklistGoal(target) { Name = name, Description = description, Points = points };
                break;
            default:
                throw new ArgumentException($"Invalid goal type: {type}");
        }
        _goalList.Add(newGoal);
    }

    public void RecordGoalEvent(int index)
    {
        if (index >= 0 && index < _goalList.Count)
        {
            _goalList[index].RecordEvent();
            _currentScore += _goalList[index].Points;
        }
        else
        {
            throw new IndexOutOfRangeException("Invalid goal index.");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_currentScore);
            foreach (var goal in _goalList)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        _goalList.Clear();
        _currentScore = 0;

        using (StreamReader reader = new StreamReader(filename))
        {
            _currentScore = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(details[3]);
                        CreateGoal(type, details[0], details[1], int.Parse(details[2]));
                        break;
                    case "EternalGoal":
                        CreateGoal(type, details[0], details[1], int.Parse(details[2]));
                        break;
                    case "ChecklistGoal":
                        CreateGoal(type, details[0], details[1], int.Parse(details[2]), int.Parse(details[3]));
                        break;
                    default:
                        throw new ArgumentException($"Invalid goal type: {type}");
                }
            }
        }
    }

    public List<Goal> GetGoals()
    {
        return _goalList;
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }
}
