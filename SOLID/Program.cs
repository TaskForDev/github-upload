using System;
using System.Collections.Generic;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "";
            List<string> names = null;
            TryReadExample tryReadExample = new TryReadExample(names);
            tryReadExample.TryRead(1, out message);//helpful

        }
    }
}
