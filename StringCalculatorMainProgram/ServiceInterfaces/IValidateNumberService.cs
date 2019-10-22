using StringCalculatorMainProgram.Shares;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.ServiceInterfaces
{
    public interface IValidateNumberService
    {
        ValidatorStatus ValidateNumber(IDetectDelimitersService detectDelimitersService,
                IDetectNegativeNumbersService detectNegativeNumbersService, string numbers, string delimiter = null);
    }
}
