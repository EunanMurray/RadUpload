using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockRepeatPractice.Models
{
    public class Flights
    {
        public int FlightID { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string country { get; set; }
        public int maxSeats { get; set; }

        public virtual ICollection<Passengers> Passengers { get; set; }
    }
}
