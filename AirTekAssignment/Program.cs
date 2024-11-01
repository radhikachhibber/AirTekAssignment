// See https://aka.ms/new-console-template for more information
using AirTekAssignment.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AirTekAssignment
{
    public class Program
    {
        private IFlightService _flightService;
        public Program(IFlightService flightService)
        {
            _flightService = flightService;
        }
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                  .AddTransient<IFlightService, FlightService>()
                  .BuildServiceProvider();

            var program = new Program(
                serviceProvider.GetService<IFlightService>()
            );
            program.Start(); 
        }

        public void Start()
        {
             _flightService.GetFlightSchedule();
        }
    }
}