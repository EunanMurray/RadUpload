using Microsoft.EntityFrameworkCore;
using _2022ClassLibrary.Models;
using _2022PracticePaper.Data;

class Program
{
    static void Main(string[] args)
    {
        int answer;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n----------------\n");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("\n 1: List player details by team name, \n");

            answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    Console.WriteLine("Enter the team name: ");
                    string TeamName = Console.ReadLine();
                    Team_enquires(TeamName);
                    break;

                case 2:
                    break;

                case 3:
                    break;
            }
        }
    }

    static void Team_enquires(string TeamName)
    {
        using (var context = new DbContext2022())
        {
            var players = context.Players.Where(p => p.Team.TeamName == TeamName).ToList();
            foreach (var player in players)
            {
                Console.WriteLine($"Player Name: {player.PlayerName}, Date of Birth: {player.DateOfBirth}, Position: {player.Position}, Registered: {player.Registered}");

            }
        }
    }
}