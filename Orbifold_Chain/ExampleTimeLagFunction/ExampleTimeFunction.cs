using Orbifold_Chain;
using System;
using Functions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleTimeLagFunction
{
    public class ExampleTimeFunction : ITimeFunction
    {
        public string TimeLagFunctionName => "ExampleTimeFunction";

        public DateTime TimeLagFunction(DateTime input_time)
        {
            User_Functions n = new User_Functions();

            var m = n.AddOneDayFunction(input_time);

            return n.AddOneDayFunction(m);
        }
    }
}
