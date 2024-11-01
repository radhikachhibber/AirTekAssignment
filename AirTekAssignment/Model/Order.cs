using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTekAssignment.Model
{
    public class Order
    {
        public string? FlightNo { get; set; }
        public string? OrderId { get; set; }
        public string? Departure { get; set; }
        public string? Destination { get; set; }
        public int Day { get; set; }
    }
}
