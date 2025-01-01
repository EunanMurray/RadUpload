namespace MockLibrary.Models
{
    public class Passengers
    {
        public int PassengerID { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}