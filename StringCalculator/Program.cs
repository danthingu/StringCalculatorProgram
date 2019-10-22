using StringCalculatorMainProgram;
using StringCalculatorMainProgram.Services;
using System;

namespace StringCalculator
{
    class Program
    {
        //Dependency Injection(DI) patterns are all about removing dependencies from your code.
        static void Main(string[] args) =>
            _ = new StringCalculatorMainApplication(new ValidateNumberService(), new CleanedNumberStringService(), new DetectDelimitersService(), new DetectNegativeNumbersService());
    }
}
