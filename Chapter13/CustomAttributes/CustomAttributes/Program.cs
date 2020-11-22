using System;
using System.Diagnostics;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    class DoesInterestingThingsAttribute : Attribute
    {
        public DoesInterestingThingsAttribute(int howManyTimes)
        {
            HowManyTimes = howManyTimes;
        }

        public string WhatDoesItDo { get; set; }

        public int HowManyTimes { get; private set; }
    }

    [DoesInterestingThings(1000, WhatDoesItDo = "karma")]
    public class DecoratedClass
    {
        [DebuggerStepThrough]
        public void DullMethod()
        {
            return;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type classType = typeof(DecoratedClass);
            object[] customAttributes = classType.GetCustomAttributes(true);
            foreach (object customAttribute in customAttributes)
            {
                Console.WriteLine($"Attribute of type {customAttribute} found.");
                DoesInterestingThingsAttribute interestingAttribute =
                   customAttribute as DoesInterestingThingsAttribute;
                if (interestingAttribute != null)
                {
                    Console.WriteLine($"This class does {interestingAttribute.WhatDoesItDo} x " +
                        $"{interestingAttribute.HowManyTimes}!");
                }
            }

            Console.ReadKey();
        }
    }
}
