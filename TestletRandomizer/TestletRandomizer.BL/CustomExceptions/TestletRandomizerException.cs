using System;

namespace TestletRandomizer.BL.CustomExceptions
{
    public class TestletRandomizerException : Exception
    {
        public TestletRandomizerException(string message) : base(message)
        {

        }
    }
}