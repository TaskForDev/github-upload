using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SOLID
{
    public class TryReadExample
    {
        public int MyProperty { get; set; }

        public readonly List<string> Names;

        public TryReadExample(List<string> names)
        {
            Names = new List<string>();
            Names.AddRange(names);
        }

        private bool Exist(string id)
        {
            return Names.Where(n => n.Contains(id)).Count( ) > 0 ;
        }
        public bool TryRead(int id,out string message)
        {
            message = "";             /// condition 
            if (!Exist(""))
                return false;
            else
            {
                message = "Read is done!!!";
                return true;
            }
        }
    }
}
