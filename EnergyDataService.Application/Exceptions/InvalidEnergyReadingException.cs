using System;

namespace EnergyDataService.Application.Exceptions;

public sealed class InvalidEnergyReadingException : Exception
{
    public InvalidEnergyReadingException(string message)
        : base(message)
    {
    }
}
