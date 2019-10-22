using StringCalculatorMainProgram.Shares;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.ServiceInterfaces
{
    public interface IValidateNumberService
    {
        ValidatorStatus ValidateNumber(string numbers, string delimiter = null);
    }
}
