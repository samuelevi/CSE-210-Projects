/*
EXCEEDING REQUIREMENTS REPORT:
1. Persistent Activity Logging: Implemented an ActivityLogger class that saves session data to 'activity_log.json' using JSON serialization, allowing progress tracking across multiple sessions.
2. Activity Summary Dashboard: Added a new menu option (Choice 4) that calculates and displays the total count for each activity and the cumulative time spent across all sessions.
3. Intelligent Randomization: Enhanced Reflection and Listing activities to track used prompts and questions. No item is repeated until the entire list has been exhausted, ensuring a varied and fresh user experience.
4. Robust Architecture: Utilized the Single Responsibility Principle by separating data persistence and logging logic into its own service class, keeping the activity classes focused solely on their mindfulness logic.
*/


using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        
        ActivityLogger logger = new ActivityLogger();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity summary");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    logger.DisplaySummary();
                    Console.WriteLine("Press Enter to return to menu...");
                    Console.ReadLine();
                    continue;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            if (activity != null)
            {
                activity.Run();
                logger.LogActivity(activity.GetName(), activity.GetDuration());
            }
        }
    }
}