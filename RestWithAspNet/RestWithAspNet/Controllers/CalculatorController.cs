using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithAspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly string INVALID_INPUT = "Invalid input";

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }

            return BadRequest(INVALID_INPUT);
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }

            return BadRequest(INVALID_INPUT);
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }

            return BadRequest(INVALID_INPUT);
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }

            return BadRequest(INVALID_INPUT);
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(result.ToString());
            }

            return BadRequest(INVALID_INPUT);
        }

        [HttpGet("sqrt/{number}")]
        public IActionResult Sqrt(string number)
        {
            if(IsNumeric(number))
            {
                var result = Math.Sqrt((double) ConvertToDecimal(number));
                return Ok(result.ToString());
            }

            return BadRequest(INVALID_INPUT);
        }

        private bool IsNumeric(string value)
        {
            double number;
            bool isNumber = double.TryParse(
                value, 
                NumberStyles.Any, 
                NumberFormatInfo.InvariantInfo, 
                out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string value)
        {
            decimal decimalValue;
            if(decimal.TryParse(value, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}
