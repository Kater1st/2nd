using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(goalManager);
                    break;
                case "2":
                    ListGoals(goalManager);
                    break;
                case "3":
                    Console.Write("Enter filename to save goals: ");
                    string saveFile = Console.ReadLine();
                    goalManager.SaveGoals(saveFile);
                    Console.WriteLine("Goals saved successfully.");
                    break;
                case "4":
                    Console.Write("Enter filename to load goals: ");
                    string loadFile = Console.ReadLine();
                    goalManager.LoadGoals(loadFile);
                    Console.WriteLine("Goals loaded successfully.");
                    break;
                case "5":
                    RecordGoalEvent(goalManager);
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal(GoalManager goalManager)
    {
        Console.Write("Enter goal type (SimpleGoal, EternalGoal, ChecklistGoal): ");
        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());
        int target = 0;

        if (type == "ChecklistGoal")
        {
            Console.Write("Enter target number of completions: ");
            target = int.Parse(Console.ReadLine());
        }

        goalManager.CreateGoal(type, name, description, points, target);
        Console.WriteLine("Goal created successfully.");
    }

    static void ListGoals(GoalManager goalManager)
    {
        var goals = goalManager.GetGoals();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("\nGoals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStringRepresentation()}");
        }
    }

    static void RecordGoalEvent(GoalManager goalManager)
    {
        ListGoals(goalManager);
        Console.Write("Select the goal index to record an event: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        try
        {
            goalManager.RecordGoalEvent(index);
            Console.WriteLine("Event recorded successfully.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid goal index.");
        }
    }
}