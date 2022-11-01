namespace iPractice.Application.Dtos;

public record AvailabilityDto
{
    public long PsychologistId { get; init; }
    public long AvailabilityId { get; init; }
    public DateTime FromTime { get; init; }
    public DateTime ToTime { get; init; }
    public DayOfWeek DayOfWeek { get; init; }

}