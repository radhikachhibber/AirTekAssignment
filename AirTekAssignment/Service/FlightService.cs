using AirTekAssignment.Model;
using Newtonsoft.Json;

namespace AirTekAssignment.Service
{
    public class FlightService : IFlightService
    {
        public FlightService() { }

        public void GetFlightSchedule()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "flight-schedules.json");
            var jsonData = File.ReadAllText(path);
            var flights = JsonConvert.DeserializeObject<List<Flight>>(jsonData);
            if (flights != null)
            {
                foreach (var flight in flights)
                {
                    Console.WriteLine($"Flight: {flight.FlightNo}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
                }
                LoadOrders(flights); // User Story 2
            }
        }

        private void LoadOrders(List<Flight> flights)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "coding-assigment-orders.json");
            var jsonData = File.ReadAllText(path);
            var orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(jsonData);
            if (orders != null)
            {
                var scheduledOrders =  new List<Order>();
                foreach (var order in orders)
                {
                    bool isLoaded = false;
                    foreach (var flight in flights)
                    {
                        if (order.Value.Destination == flight.ArrivalCity && flight.OrdersLoaded < 20) // 20 is the max capacity of each flight
                        {
                            flight.OrdersLoaded++ ;
                            scheduledOrders.Add(new Order { 
                                Departure = flight.DepartureCity,
                                Destination = flight.ArrivalCity,
                                Day = flight.Day,
                                FlightNo = flight.FlightNo,
                                OrderId = order.Key 
                            }); isLoaded = true;
                            break; //one order loaded per flight
                        }
                    }
                    if (!isLoaded) // order not scheduled
                    {
                        scheduledOrders.Add( new Order { FlightNo = "not scheduled", OrderId = order.Key });
                    }
                }
                
                foreach (var order in scheduledOrders)
                {
                    if(order.FlightNo == "not scheduled")
                        Console.WriteLine($"order: {order.OrderId}, flightNumber: {order.FlightNo}");
                    else
                        Console.WriteLine($"order: {order.OrderId}, flightNumber: {order.FlightNo}, departure: {order.Departure}, arrival: {order.Destination}, day: {order.Day}");
                }
            }
        }
    }
}
