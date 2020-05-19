using SOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string Description, CustomErrorCode errorcode, string Message) :  base(errorcode)
        {
            CustomErrorDetails customErrorDetails = new CustomErrorDetails();
            customErrorDetails.Message = Message;
            customErrorDetails.Description = Description;
            customErrorDetails.errorcode = errorcode;
        }
    }
}
