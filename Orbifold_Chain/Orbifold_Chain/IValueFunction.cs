using System;

namespace Orbifold_Chain
{
    public interface IValueFunction
    {
        string ValueFuncitonName { get; }
        Double ValueFunction(DateTime input_time);
    }
}
