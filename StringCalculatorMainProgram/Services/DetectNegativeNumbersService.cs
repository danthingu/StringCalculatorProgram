using StringCalculatorMainProgram.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorMainProgram.Services
{
    public class DetectNegativeNumbersService : IDetectNegativeNumbersService
    {
        private IDetectDelimitersService _detectDelimitersService;
        private string _numbers;
        private string _delimiters;
        public bool isNegativeNumbersExistInString(IDetectDelimitersService detectDelimitersService, string numbers, string delimiters)
        {
            _detectDelimitersService = detectDelimitersService;
            _numbers = numbers;
            _delimiters = delimiters;
            return GetNegativeNumbers().Any();
        }
        private IEnumerable<int> GetNegativeNumbers() =>(from num in _detectDelimitersService.SplitDelimiters(_numbers, _delimiters) where int.TryParse(num, out int n) == true && int.Parse(num) < 0 select int.Parse(num)).ToArray();
        public override string ToString() => String.Join(", ", GetNegativeNumbers().Distinct().ToArray()); 
    }
}
