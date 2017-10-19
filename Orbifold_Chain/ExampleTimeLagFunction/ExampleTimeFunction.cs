using Orbifold_Chain;
using System;
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
            return input_time.AddDays(1);
        }
    }
}
