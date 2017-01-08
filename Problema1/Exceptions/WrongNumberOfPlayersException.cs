using System;

namespace Problema1.Exceptions
{
    public class WrongNumberOfPlayersException : Exception
    {
        public WrongNumberOfPlayersException(string message) : base(message)
        {

        }
    }
}
