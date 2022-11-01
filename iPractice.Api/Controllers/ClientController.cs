using iPractice.Api.Mappings;
using iPractice.Api.Responses;
using iPractice.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace iPractice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        /// <summary>
        /// The client can see when his psychologists are available.
        /// Get available slots from his two psychologists.
        /// </summary>
        /// <param name="clientId">The client ID</param>
        /// <returns>All time slots for the selected client</returns>
        [HttpGet("{clientId}/timeslots")]
        [ProducesResponseType(typeof(IEnumerable<TimeSlot>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<TimeSlot>> GetAvailableTimeSlots(long clientId)
        {
            var availabilities = await _clientService.GetAvailableTimeSlots(clientId);
            return availabilities.ToApiResponse();
        }

        /// <summary>
        /// Create an appointment for a given availability slot
        /// </summary>
        /// <param name="clientId">The client ID</param>
        /// <param name="timeSlot">Identifies the client and availability slot</param>
        /// <returns>Ok if appointment was made</returns>
        [HttpPost("{clientId}/appointment")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateAppointment(long clientId, [FromBody] TimeSlot timeSlot)
        {
            await _clientService.CreateAppointment(clientId, timeSlot.PsychologistId, timeSlot.AvailabilityId, timeSlot.FromTime);
            return Ok();
        }
    }
}
