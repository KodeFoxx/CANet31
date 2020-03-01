using System;

namespace Kf.CANet31.Core.Domain.People
{
    public sealed class InvalidNameException : Exception
    {
        public InvalidNameException(string message)
            : base(message, null)
        { }

        public InvalidNameException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
