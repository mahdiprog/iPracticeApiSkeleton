using iPractice.Application.Dtos;

namespace iPractice.Api.Mappings
{
    public static class RequestsMapping
    {
        public static AvailabilityDto ToDto(this CreateAvailabilityRequest request, long psychologistId)
        {
            return new AvailabilityDto
            {
                DayOfWeek = request.DayOfWeek,
                FromTime = request.FromTime,
                ToTime = request.ToTime,
                PsychologistId = psychologistId
            };
        }
    }
}
