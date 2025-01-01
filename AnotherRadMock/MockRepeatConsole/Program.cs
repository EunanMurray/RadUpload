using Microsoft.EntityFrameworkCore;
using MockRepeatConsole.Data;
using MockRepeatPractice.Models;

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
            Console.WriteLine("\n 1: List all passengers on a flight, \n 2: List the revenue for a flight, \n 3: Add a passenger to a flight, \n 4: Exit");

            answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    Console.WriteLine("Enter the Flight ID: ");
                    int FlightID1 = Convert.ToInt32(Console.ReadLine());
                    list_passengers(FlightID1);
                    break;
                case 2:
                    Console.WriteLine("Enter the Flight ID: ");
                    int FlightID2 = Convert.ToInt32(Console.ReadLine());
                    list_flight_revenue(FlightID2);
                    break;
                case 3:
                    add_passenger(new Passengers());
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }


    static void list_passengers(int FlightID)
    {
        using (var context = new DbContextS00235207())
        {
            var passengers = context.Passengers
                .Include(p => p.Flight)
                .Where(p => p.FlightID == FlightID)
                .ToList();
            foreach (var p in passengers)
            {
                Console.WriteLine($"Passenger Name: {p.Name}, Ticket Type: {p.TicketType}, Destination: {p.Flight.destination}");
            }
        }
    }
    static void list_flight_revenue(int FlightID)
    {
        using (var context = new DbContextS00235207())
        {
            var passengers = context.Passengers.Where(p => p.FlightID == FlightID).ToList();
            double total = 0;
            foreach (var p in passengers)
            {
                total += p.cost + p.baggageCharge;
            }
            Console.WriteLine($"Total Revenue for Flight {FlightID}: {total}");
        }
    }

    static void add_passenger(Passengers p)
    {
        using (var context = new DbContextS00235207())
        {
            var passenger = new Passengers
            {
                Name = "Monica Ward",
                TicketType = "First Class",
                cost = 150.00,
                baggageCharge = 30.00,
                FlightID = 1
            };

            context.Passengers.Add(passenger);
            context.SaveChanges();
            Console.WriteLine("Passenger added successfully");
        }

    }
}
