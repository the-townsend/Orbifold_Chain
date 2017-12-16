using System;

namespace Functions

{
    public class User_Functions
    {
        public DateTime AddOneDayFunction(DateTime input_time)
        {
            return input_time.AddDays(1);
        }
    }

}