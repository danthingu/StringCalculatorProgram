using StringCalculatorMainProgram.ServiceInterfaces;
using StringCalculatorMainProgram.Shares;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram
{
    public class StringCalculatorMainApplication
    {
        IValidateNumberService _validateNumberService;
        ICleanedNumberStringService _cleanedNumberStringService;
        IDetectDelimitersService _delimiterDetectionService;
        IDetectNegativeNumbersService _detectNegativeNumbersService;
        public StringCalculatorMainApplication(IValidateNumberService validateNumberService, ICleanedNumberStringService cleanedNumberStringService, 
            IDetectDelimitersService delimiterDetectionService, IDetectNegativeNumbersService detectNegativeNumbersService)
        {
            _validateNumberService = validateNumberService;
            _cleanedNumberStringService = cleanedNumberStringService;
            _delimiterDetectionService = delimiterDetectionService;
            _detectNegativeNumbersService = detectNegativeNumbersService;
        }

        public int Add(string numbers)
        {
            dynamic formattedNumbers = _cleanedNumberStringService.CleanNumbersString(_delimiterDetectionService, numbers);
            string number = Convert.ToString(formattedNumbers.Numbers);
            string delimiter = Convert.ToString(formattedNumbers.Delimiter);

            if (_validateNumberService.ValidateNumber(_delimiterDetectionService, _detectNegativeNumbersService, number, delimiter) != ValidatorStatus.NormalNumber)
            {
                _validateNumberService.ValidateNumber(_delimiterDetectionService, _detectNegativeNumbersService, number, delimiter);
            }
            return 0;
        }
    }
}
