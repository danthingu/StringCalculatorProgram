using StringCalculatorMainProgram.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.Services
{
    public class CleanedNumberStringService : ICleanedNumberStringService
    {
        private string _numbers;
        private string _delimiters;

        public object CleanNumbersString()
        {
            return new { _numbers, _delimiters };
        }
    }
}
