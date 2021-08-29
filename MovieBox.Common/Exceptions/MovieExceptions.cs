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

    public class MovieExistsException : MovieException
    {
        private const string _baseMessage = "Movie already exists.";

        public MovieExistsException() : base(_baseMessage)
        { }

        public MovieExistsException(string message) : base($"{_baseMessage} {message}")
        { }

        public MovieExistsException(Exception innerException) : base(_baseMessage, innerException)
        { }
    }

    public class MovieNotFoundException : MovieException
    {
        private const string _baseMessage = "Movie not found.";

        public MovieNotFoundException() : base(_baseMessage)
        { }

        public MovieNotFoundException(string message) : base($"{_baseMessage} {message}")
        { }

        public MovieNotFoundException(Exception innerException) : base(_baseMessage, innerException)
        { }
    }
}