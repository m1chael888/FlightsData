using FlightsData.Data;
using FlightsData.Models;

namespace FlightsData.Services
{
    public interface IFlightsService
    {
        public List<Flight> GetAllFlights();
        public Flight? GetFlightById(int id);
        public Flight CreateFlight(Flight flight);
        public Flight UpdateFlight(int id, Flight updatedFlight);
        public string? DeleteFlight(int id);
    }
    public class FlightsService : IFlightsService
    {
        private readonly FlightsContext _dbContext;
        public FlightsService(FlightsContext DbContext)
        {
            _dbContext = DbContext;
        }

        public Flight CreateFlight(Flight flight)
        {
            var newFlight = _dbContext.Flights.Add(flight);
            _dbContext.SaveChanges();
            return newFlight.Entity;
        }

        public List<Flight> GetAllFlights()
        {
            return _dbContext.Flights.ToList();
        }

        public Flight? GetFlightById(int id)
        {
            return _dbContext.Flights.Find(id);
        }

        public Flight UpdateFlight(int id, Flight updatedFlight)
        {
            var targetFlight = _dbContext.Flights.Find(id);

            if (targetFlight == null) return null;

            _dbContext.Entry(targetFlight).CurrentValues.SetValues(updatedFlight);
            _dbContext.SaveChanges();

            return targetFlight;
        }

        public string? DeleteFlight(int id)
        {
            var targetFlight = _dbContext.Flights.Find(id);

            if (targetFlight == null) return null;

            _dbContext.Flights.Remove(targetFlight);
            _dbContext.SaveChanges();

            return $"Flight with id {id} deleted successfully";
        }
    }
}
