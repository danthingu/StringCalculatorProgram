using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.ServiceInterfaces
{
    public interface IDetectNegativeNumbersService
    {
        bool isNegativeNumbersExistInString(IDetectDelimitersService delimiterDetectionService, string numbers, string delimiters);
    }
}
