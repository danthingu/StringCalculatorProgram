using StringCalculatorMainProgram.ServiceInterfaces;
using StringCalculatorMainProgram.Shares;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.Services
{
    public class ValidateNumberService : IValidateNumberService
    {
        public ValidatorStatus ValidateNumber(string numbers, string delimiter = null)
        {
            if (CheckNoNumbersExist(numbers)) return ValidatorStatus.NoNumbers;

            return ValidatorStatus.NormalNumber;
        }

        private bool CheckNoNumbersExist(string numbers) => String.IsNullOrWhiteSpace(numbers);
        
    }
}
