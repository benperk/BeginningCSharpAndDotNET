using System;
using System.Diagnostics;

namespace AssertionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int myVar = 15;
            Trace.Assert(myVar < 10, "Variable out of bounds.",
                "Please contact vendor with the error code KCW001.");
        }
    }
}