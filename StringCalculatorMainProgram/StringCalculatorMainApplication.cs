using StringCalculatorMainProgram.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorMainProgram
{
    public class StringCalculatorMainApplication
    {
        IValidateNumberService _validateNumberService;
        ICleanedNumberStringService _cleanedNumberStringService;
        IDelimiterDetectionService _delimiterDetectionService;
        public StringCalculatorMainApplication(IValidateNumberService validateNumberService, ICleanedNumberStringService cleanedNumberStringService, IDelimiterDetectionService delimiterDetectionService)
        {
            _validateNumberService = validateNumberService;
            _cleanedNumberStringService = cleanedNumberStringService;
            _delimiterDetectionService = delimiterDetectionService;
        }
    }
}
