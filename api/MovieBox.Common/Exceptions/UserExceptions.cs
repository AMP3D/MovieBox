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

    public class UserLoginInvalidException : UserException
    {
        private const string _baseMessage = "User login is invalid.";

        public UserLoginInvalidException() : base(_baseMessage)
        { }

        public UserLoginInvalidException(string message) : base($"{_baseMessage} {message}")
        { }

        public UserLoginInvalidException(Exception innerException) : base(_baseMessage, innerException)
        { }
    }

    public class UserNotFoundException : UserException
    {
        private const string _baseMessage = "User not found.";

        public UserNotFoundException() : base(_baseMessage)
        { }

        public UserNotFoundException(string message) : base($"{_baseMessage} {message}")
        { }

        public UserNotFoundException(Exception innerException) : base(_baseMessage, innerException)
        { }
    }
}