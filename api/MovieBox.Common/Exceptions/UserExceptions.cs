using System;

namespace MovieBox.Common.Exceptions
{
    public class UserException : Exception
    {
        public UserException() : base()
        { }

        public UserException(string message) : base(message)
        { }

        public UserException(string message, Exception innerException) : base(message, innerException)
        { }
    }

    public class UserExistsException : UserException
    {
        private const string _baseMessage = "User already exists.";

        public UserExistsException() : base(_baseMessage)
        { }

        public UserExistsException(string message) : base($"{_baseMessage} {message}")
        { }

        public UserExistsException(Exception innerException) : base(_baseMessage, innerException)
        { }
    }
}