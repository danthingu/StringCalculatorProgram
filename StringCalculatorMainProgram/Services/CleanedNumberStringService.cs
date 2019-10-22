using StringCalculatorMainProgram.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorMainProgram.Services
{
    public class CleanedNumberStringService : ICleanedNumberStringService
    {
        public string Numbers;
        public string Delimiters;
        private string GetNumbersAfterCleaned(string numbers) => !Delimiters.Contains(',') ? numbers.Substring(Delimiters.Length + 3).Replace("\n", Delimiters) : numbers.Replace("\n", Delimiters);
        public object CleanNumbersString(IDetectDelimitersService detectDelimitersService, string numbers)
        {
            Delimiters = detectDelimitersService.GetIdentifier(numbers).Aggregate("", (current, item) => current + item.ToString());
            Numbers = GetNumbersAfterCleaned(numbers);
            return new { Numbers, Delimiters };
        }
    }
}
