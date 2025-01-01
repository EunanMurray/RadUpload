using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockRepeatPractice.Models
{
    public class Passengers
    {
        public int PassengerID { get; set; }
        public string Name { get; set; }
        public string TicketType { get; set; }
        public double cost { get; set; }
        public double baggageCharge { get; set; }
        public int FlightID { get; set; }
        public virtual Flights Flight { get; set; }
    }
}
