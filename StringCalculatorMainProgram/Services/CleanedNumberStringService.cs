using StringCalculatorMainProgram.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorMainProgram.Services
{
    public class CleanedNumberStringService : ICleanedNumberStringService
    {
        private string _numbers;
        private string _delimiters;

        private string GetNumbersAfterCleaned(string numbers) => !_delimiters.Contains(',') ? numbers.Substring(_delimiters.Length + 3).Replace("\n", _delimiters) : numbers.Replace("\n", _delimiters);

        public object CleanNumbersString(IDetectDelimitersService delimiterDetectionService, string numbers)
        {
            _delimiters = delimiterDetectionService.GetIdentifier(numbers).Aggregate("", (current, item) => current + item.ToString());
            _numbers = GetNumbersAfterCleaned(numbers);
            return new { _numbers, _delimiters };
        }
    }
}
