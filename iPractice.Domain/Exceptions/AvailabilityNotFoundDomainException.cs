using System;

namespace iPractice.Domain.Exceptions;

public class AvailabilityNotFoundDomainException : Exception
{
    public AvailabilityNotFoundDomainException()
    { }

    public AvailabilityNotFoundDomainException(string message)
        : base(message)
    { }

    public AvailabilityNotFoundDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
