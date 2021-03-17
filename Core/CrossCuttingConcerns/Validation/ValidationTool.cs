using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            //ProductValidator productValidator = new ProductValidator();
            var res = validator.Validate(context);
            if (!res.IsValid)
            {
                throw new ValidationException(res.Errors);
            }
        }
    }
}
