using StringCalculatorMainProgram.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram.Services
{
    public class DetectDelimitersService : IDetectDelimitersService
    {
        public char[] GetIdentifier(string numbers)
        {
            var delimiter = "";
            foreach (var item in numbers)
            {
                if (item == '\n')
                {
                    break;
                }
                delimiter += item.ToString();

            }
            return numbers.Length > 1 && (numbers[0] == '/' && numbers[1] == '/') ? delimiter.Substring(2).ToCharArray() : new[] { ',' };
        }
        public string[] SplitDelimiters(string numbers, string delimiter) => numbers.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }
}
