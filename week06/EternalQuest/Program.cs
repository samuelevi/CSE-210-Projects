using System;

/*
CREATIVITY REQUIREMENTS:
1. Leveling System: Added a leveling system where the user's level is calculated based on their total score (1 level per 1000 points).
2. Rank System: Added dynamic ranks that change based on the user's level.
3. Negative Goals: Implemented a 'NegativeGoal' class that allows users to track bad habits. Recording an event for a negative goal subtracts points from the user's score, encouraging them to avoid those behaviors.
4. Level/Rank Display: The current level and rank are displayed alongside the score in the main menu to provide more visual feedback and gamification.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}