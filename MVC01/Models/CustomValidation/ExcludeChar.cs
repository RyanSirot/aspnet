﻿using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVC01.Models.CustomValidation
{
    public class ExcludeChar : ValidationAttribute
    {
        private readonly string _chars;
        // [Exclude ("^%$#@!")]

        public ExcludeChar(string chars) : base("{0} contains invalid character.")
        {
            _chars = chars;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null) {
                for (int i = 0; i < _chars.Length; i++) {
                    var valueAsString = value.ToString();
                    if (valueAsString.Contains(_chars[i])) {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}