using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.Shares
{
    class NegativeNumberException: Exception
    {
        public NegativeNumberException(string message) : base(message)
        {
        }
    }
}
