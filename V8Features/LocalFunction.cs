using System;
using System.Collections.Generic;
using System.Text;

namespace V8Features
{
    public class LocalFunction
    {
        private static string Field ="modified!";
        public void Run()
        {
            var state = "1";

            DoSomethingWithState();
            DoSomethingWithField();

            Console.WriteLine($"state: {state}");
            Console.WriteLine($"Field: {Field}");

            string DoSomethingWithState()
            {
                return state = "99";
            }

            static string DoSomethingWithStateStatic()  //Do not capture state 
            {
                return "99";
            }

            static string DoSomethingWithField() 
            {
                return Field = "modified!";
            }

        }
    }
}
