using StringCalculatorMainProgram.ServiceInterfaces;
using StringCalculatorMainProgram.Shares;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.Services
{
    public class ValidateNumberService : IValidateNumberService
    {
        public ValidatorStatus ValidateNumber(IDetectDelimitersService delimiterDetectionService, IDetectNegativeNumbersService detectNegativeNumbersService, string numbers, string delimiters = null)
        {
            if (CheckNoNumbersExist(numbers)) return ValidatorStatus.NoNumbers;
            if (CheckIfOnlyContainOneNumber(numbers)) return ValidatorStatus.SingleNumber;
            if (IsNegative(detectNegativeNumbersService, delimiterDetectionService, numbers, delimiters)) throw new NegativeNumberException($"Error! There is a negative number");

            return ValidatorStatus.NormalNumber;
        }
        private bool IsNegative(IDetectNegativeNumbersService detectNegativeNumbersService, IDetectDelimitersService delimiterDetectionService, string numbers, string delimiters) 
        {
            return detectNegativeNumbersService.isNegativeNumbersExistInString(delimiterDetectionService, numbers, delimiters) ? true : false;
        }
        private bool CheckNoNumbersExist(string numbers) => String.IsNullOrWhiteSpace(numbers);
        private bool CheckIfOnlyContainOneNumber(string numbers) => int.Parse(numbers) > 0 && numbers.Length == 1;
    }
}
