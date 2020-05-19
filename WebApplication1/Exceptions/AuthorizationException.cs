using SOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class AuthorizationException : BaseException
    {
        public AuthorizationException(string Description , string message) : base(HttpStatusCode.Forbidden)
        {
            CustomErrorDetails CustomErrorDetails = new CustomErrorDetails();
            CustomErrorDetails.Description = Description;
            CustomErrorDetails.Message = message;
            customErrorDetails = CustomErrorDetails;
        }
    }
}
