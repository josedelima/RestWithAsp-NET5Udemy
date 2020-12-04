using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtract = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtract.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var secondNumberDecimal = ConvertToDecimal(secondNumber);
                if (secondNumberDecimal != 0)
                {
                    var div = ConvertToDecimal(firstNumber) / secondNumberDecimal;
                    return Ok(div.ToString());
                }

            }

            return BadRequest("Invalid input");
        }

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        public IActionResult Avg(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var avg = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(avg.ToString());

            }

            return BadRequest("Invalid input");
        }

        [HttpGet("sqrt/{number}")]
        public IActionResult Sqrt(string number)
        {
            if (IsNumeric(number))
            {

                var sqrt = Math.Sqrt(ConvertToDouble(number));
                return Ok(sqrt.ToString());

            }

            return BadRequest("Invalid input");
        }

        private double ConvertToDouble(string strNumber)
        {
            double doubleNumber;
            if (double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out doubleNumber))
            {
                return doubleNumber;
            }

            return 0;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalNumber;
            if (decimal.TryParse(strNumber, out decimalNumber))
            {
                return decimalNumber;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;

        }
    }
}
