using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _7_TRPO.Validations
{
    public class Numbers : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (!float.TryParse(input, out float floatValue))
            {
                return new ValidationResult(false, "необходимо ввести число");
            }

            return ValidationResult.ValidResult;
        }
    }
}
