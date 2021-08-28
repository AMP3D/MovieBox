using System;

namespace MovieBox.Common.Exceptions
{
    public class MovieException : Exception
    {
        public MovieException() : base()
        { }

        public MovieException(string message) : base(message)
        { }

        public MovieException(string message, Exception innerException) : base(message, innerException)
        { }
    }

    public class MovieNotFoundException : MovieException
    {
        private const string _baseMessage = "Movie not found.";

        public MovieNotFoundException() : base(_baseMessage)
        { }

        public MovieNotFoundException(Exception innerException) : base(_baseMessage, innerException)
        { }
    }
}