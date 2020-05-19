using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SOLID
{
    public class ModelValidatorException : BaseException
    {
        public ModelValidatorException(string message ,string Description, string errorcode ) : base(HttpStatusCode.BadRequest)
        {
            
        }
        public ModelValidatorException(string message, string errorcode, string Description, CustomErrorDetails ValidationFailures) : base(HttpStatusCode.BadRequest)
        {
            ValidationFailures.Description = Description;
            ValidationFailures.Message = message;
            customErrorDetails = ValidationFailures;
        }
    }
}
