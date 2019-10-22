using StringCalculatorMainProgram.ServiceInterfaces;
using StringCalculatorMainProgram.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorMainProgram
{
    public class StringCalculatorMainApplication
    {
        IValidateNumberService _validateNumberService;
        ICleanedNumberStringService _cleanedNumberStringService;
        IDetectDelimitersService _detectDelimitersService;
        IDetectNegativeNumbersService _detectNegativeNumbersService;
        public StringCalculatorMainApplication(IValidateNumberService validateNumberService, ICleanedNumberStringService cleanedNumberStringService, 
            IDetectDelimitersService detectDelimitersService, IDetectNegativeNumbersService detectNegativeNumbersService)
        {
            _validateNumberService = validateNumberService;
            _cleanedNumberStringService = cleanedNumberStringService;
            _detectDelimitersService = detectDelimitersService;
            _detectNegativeNumbersService = detectNegativeNumbersService;
        }

        public int Add(string num)
        {
            dynamic formattedNumbers = _cleanedNumberStringService.CleanNumbersString(_detectDelimitersService, num);
            string numbers = Convert.ToString(formattedNumbers.Numbers);
            string delimiters = Convert.ToString(formattedNumbers.Delimiters);

            if (_validateNumberService.ValidateNumber(_detectDelimitersService, _detectNegativeNumbersService, numbers, delimiters) != ValidatorStatus.NormalNumber)
            {
                _validateNumberService.ValidateNumber(_detectDelimitersService, _detectNegativeNumbersService, numbers, delimiters);
            }

            var result = GetSum(numbers, delimiters);
            Console.WriteLine($"String calculator for {numbers} is {result}");
            return result;
        }

        public int GetSum(string numbers, string delimiters) => _detectDelimitersService.SplitDelimiters(numbers, delimiters).Where(numbers => int.TryParse(numbers, out int n) == true && int.Parse(numbers) <= 1000).Sum(int.Parse);
    }
}
