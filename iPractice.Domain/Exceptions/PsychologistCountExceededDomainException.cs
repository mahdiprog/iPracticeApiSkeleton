using System;

namespace iPractice.Domain.Exceptions;

public class PsychologistCountExceededDomainException : Exception
{
    public PsychologistCountExceededDomainException()
    { }

    public PsychologistCountExceededDomainException(string message)
        : base(message)
    { }

    public PsychologistCountExceededDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
