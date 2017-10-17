using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    [Serializable]
    public class Example_Function_Token : Function_Token
    {
        //public override DateTime TimeLagFunction(DateTime input_time)
        //{
        //    return new DateTime(input_time.Year,input_time.Month,input_time.Day+2);
        //}
        //public override Double ValueFunction(DateTime input_time)
        //{
        //    using (var client = new WebClient())
        //    {
        //        var contents = client.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=MSFT&f=l1");
        //        Double price = Convert.ToDouble(contents);
        //        return price;
        //    }
            
        //}
    }
}
