using System;

namespace iPractice.Domain.Exceptions;

public class AvailabilityOccupiedDomainException : Exception
{
    public AvailabilityOccupiedDomainException()
    { }

    public AvailabilityOccupiedDomainException(string message)
        : base(message)
    { }

    public AvailabilityOccupiedDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
