using MockConsole2.Data;

static void list_passengers(int FlightID)
{
    using (var context = new FlightContext())
    {
        var query = from b in context.Bookings
                    where b.FlightID == FlightID
                    select new
                    {
                        b.Passenger.Name,
                        b.TicketType,
                        b.Flight.Destination
                    };

        foreach (var result in query)
        {
            Console.WriteLine($"Passenger: {result.Name}, Ticket: {result.TicketType}, Destination: {result.Destination}");
        }
    }
}

static void list_flight_revenue()
{
    using (var context = new FlightContext())
    {
        var query = from b in context.Bookings
                    group b by b.FlightID into g
                    select new
                    {
                        FlightID = g.Key,
                        Revenue = g.Sum(b => b.TicketCost)
                    };
        foreach (var result in query)
        {
            Console.WriteLine($"Flight: {result.FlightID}, Revenue: {result.Revenue}");
        }
    }
}