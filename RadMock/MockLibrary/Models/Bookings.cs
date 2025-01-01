namespace MockLibrary.Models
{
    public class Bookings
    {
        public int BookingID { get; set; }
        public TicketType TicketType { get; set; }
        public decimal TicketCost { get; set; }
        public int BaggageCharge { get; set; }

        public int FlightID { get; set; }
        public int PassengerID { get; set; }
        public virtual Flights Flight { get; set; }
        public virtual Passengers Passenger { get; set; }
    }

    public enum TicketType
    {
        Economy,
        FirstClass
    }
}