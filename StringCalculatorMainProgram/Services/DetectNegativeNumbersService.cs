﻿using StringCalculatorMainProgram.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorMainProgram.Services
{
    public class DetectNegativeNumbersService : IDetectNegativeNumbersService
    {
        private readonly string _numbers;
        private readonly string _delimiter;
        IDelimiterDetectionService _delimiterDetectionService;
        public DetectNegativeNumbersService(IDelimiterDetectionService delimiterDetectionService, string numbers, string delimiter)
        {
            _delimiterDetectionService = delimiterDetectionService;
            _numbers = numbers;
            _delimiter = delimiter;
        }

        public bool isNegativeNumbersExistInString() => GetNegativeNumbers().Any();

        private IEnumerable<int> GetNegativeNumbers() => (from num in _delimiterDetectionService.SplitDelimiters(_numbers, _delimiter) where int.TryParse(num, out int n) == true && int.Parse(num) < 0 select int.Parse(num)).ToArray();

        public override string ToString() => String.Join(", ", GetNegativeNumbers().Distinct().ToArray()); 
    }
}
