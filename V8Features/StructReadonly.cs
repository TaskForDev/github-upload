using System;
using System.Collections.Generic;
using System.Text;

namespace V8Features
{
    public class StructReadonly
    {
    }

    public struct Axis
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public void MoveTo(double x, double y, double z) => (X, Y, Z) = (x, y, z);
        public readonly (double X, double Y, double Z) AsTuple() => (X, Y, Z);
        public override readonly string ToString()  //Creates copy Tuple which is immutable
        {
            return AsTuple().ToString();
        }
    }
}
