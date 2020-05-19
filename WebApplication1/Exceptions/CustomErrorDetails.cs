using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    public class CustomErrorDetails 
    {
        public CustomErrorCode errorcode { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
    }
}
