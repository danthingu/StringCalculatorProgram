using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.ServiceInterfaces
{
    public interface ICleanedNumberStringService
    {
        public object CleanNumbersString(IDetectDelimitersService detectDelimitersService, string numbers);
    }
}
