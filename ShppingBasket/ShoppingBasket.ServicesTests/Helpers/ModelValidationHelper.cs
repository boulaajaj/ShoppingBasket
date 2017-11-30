﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingBasket.Services.Tests.Helpers
{
    public class ModelValidationHelper
    {
        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);

            Validator.TryValidateObject(model, validationContext, results, true);

            if (model is IValidatableObject)
                (model as IValidatableObject).Validate(validationContext);

            return results;
        }
    }
}