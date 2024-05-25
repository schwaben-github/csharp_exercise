// Changed target framework of SpecFlowCalc.Specs to .NET 8.0 in the properties

using System;
using System.Collections.Generic;

namespace SpecFlowCalc
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
    }
}
