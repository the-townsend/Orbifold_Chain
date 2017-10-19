using System;

namespace Orbifold_Chain
{
    public interface ITimeFunction
    {
        string TimeLagFunctionName { get; }
        DateTime TimeLagFunction(DateTime input_time);
    }
}