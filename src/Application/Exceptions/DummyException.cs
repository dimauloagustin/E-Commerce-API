using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class DummyException : Exception
    {
        public DummyException(string message) : base(message) { }
    }
}
