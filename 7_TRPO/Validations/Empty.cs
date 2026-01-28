using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _7_TRPO.Validations
{
    public class Empty : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод поля обязателен");
            }

            return ValidationResult.ValidResult;
        }
    }
}