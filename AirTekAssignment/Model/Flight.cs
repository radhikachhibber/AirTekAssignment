using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTekAssignment.Model
{
    public class Flight
    {
        public string? FlightNo { get; set; }
        public int Day { get; set; }
        public string? DepartureCity { get; set; }
        public string? ArrivalCity { get; set; }
        public int OrdersLoaded { get; set; } = 0;

    }
}
