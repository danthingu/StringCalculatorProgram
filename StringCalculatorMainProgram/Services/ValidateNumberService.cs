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
            if (CheckIfOnlyContainOneNumber(numbers)) return ValidatorStatus.SingleNumber;

            return ValidatorStatus.NormalNumber;
        }

        private bool CheckNoNumbersExist(string numbers) => String.IsNullOrWhiteSpace(numbers);
        private bool CheckIfOnlyContainOneNumber(string numbers) => int.Parse(numbers) > 0 && numbers.Length == 1;
    }
}
