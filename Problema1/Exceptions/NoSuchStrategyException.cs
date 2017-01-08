using System;

namespace Problema1.Exceptions
{
    public class NoSuchStrategyException : Exception
    {
        public NoSuchStrategyException(string message) : base(message)
        {
            
        }
    }
}
