using StringCalculatorMainProgram.ServiceInterfaces;
using StringCalculatorMainProgram.Shares;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.Services
{
    public class ValidateNumberService : IValidateNumberService
    {
        public ValidatorStatus ValidateNumber(IDetectDelimitersService detectDelimitersService, IDetectNegativeNumbersService detectNegativeNumbersService, string numbers, string delimiters = null)
        {
            if (CheckNoNumbersExist(numbers)) return ValidatorStatus.NoNumbers;
            if (CheckIfOnlyContainOneNumber(numbers)) return ValidatorStatus.SingleNumber;
            if (IsNegative(detectNegativeNumbersService, detectDelimitersService, numbers, delimiters)) throw new NegativeNumberException($"Error! There is a negative number");

            return ValidatorStatus.NormalNumber;
        }
        private bool IsNegative(IDetectNegativeNumbersService detectNegativeNumbersService, IDetectDelimitersService detectDelimitersService, string numbers, string delimiters) 
        {
            return detectNegativeNumbersService.isNegativeNumbersExistInString(detectDelimitersService, numbers, delimiters) ? true : false;
        }
        private bool CheckNoNumbersExist(string numbers) => String.IsNullOrWhiteSpace(numbers);
        private bool CheckIfOnlyContainOneNumber(string numbers) => numbers.Length == 1 && int.Parse(numbers) > 0;
    }
}
