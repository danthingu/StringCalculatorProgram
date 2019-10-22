using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.ServiceInterfaces
{
    public interface IDelimiterDetectionService
    {
        char[] GetIdentifier(string numbers);
    }
}
