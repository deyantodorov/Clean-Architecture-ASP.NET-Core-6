using System;
using System.Collections.Generic;

using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(ValidationResult validationResult)
        {
            Errors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }

        public List<string> Errors { get; set; }
    }
}
