using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _7_TRPO.Validations
{
    public class PhoneNumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (!float.TryParse(input, out float floatValue))
            {
                return new ValidationResult(false, "номер должен состоять из цифр");
            }

            char plus = input.StartsWith("+") ? '+' : '-';
            if (plus == '-')
            {
                return new ValidationResult(false, "номер должен начинается с +");
            }

            if (input.Length > 12)
            {
                return new ValidationResult(false, "номер слишком длинный");
            }

            if (input.Length < 12)
            {
                return new ValidationResult(false, "номер слишком короткий");
            }
            return ValidationResult.ValidResult;

        }
    }
}
