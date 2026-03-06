using FlightsData.Models;
using FlightsData.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FlightsData.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsService _flightsService;
        public FlightsController(IFlightsService flightService)
        {
            _flightsService = flightService;
        }

        [HttpGet]
        public ActionResult<List<Flight>> GetAllFlights()
        {
            return Ok(_flightsService.GetAllFlights());
        }

        [HttpGet("{id}")]
        public ActionResult<Flight> GetFlightById(int id)
        {
            var result = _flightsService.GetFlightById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Flight> CreateFlight(Flight flight)
        {
            return Ok(_flightsService.CreateFlight(flight));
        }

        [HttpPut("{id}")]
        public ActionResult<Flight> UpdateFlight(int id, Flight flight)
        {
            var result = Ok(_flightsService.UpdateFlight(id, flight));

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<Flight> DeleteFlight(int id)
        {
            var result = Ok(_flightsService.DeleteFlight(id));

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}