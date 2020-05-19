using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    class CustomErrorRequestValidator : CustomErrorDetails
    {
       public  Dictionary<string,string[]> failures { get; set; }
        public CustomErrorRequestValidator()
        {
            failures = new Dictionary<string, string[]>();
        }
    }
}
