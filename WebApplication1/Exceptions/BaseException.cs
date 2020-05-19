using Microsoft.EntityFrameworkCore;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SOLID
{
    public class BaseException : Exception
    {
        public HttpStatusCode statuscode   { get; set; }
        public CustomErrorDetails customErrorDetails { get; set; }
        public CustomErrorCode errorcode { get; set; }

        public BaseException(HttpStatusCode Statuscode) 
        {
            statuscode = Statuscode;
        }

        public BaseException(CustomErrorCode Errorcode)
        {
            errorcode = Errorcode;
        }
    }
}
