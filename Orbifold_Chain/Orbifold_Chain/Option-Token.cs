using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    /// <summary>
    /// Option token consists two time poinnts and a list of pairs: (amounts,token). 
    /// </summary>
    [Serializable]
    public class Option_Token:Token
    {
        /// <summary>
        /// Start timestamp  
        /// </summary>
        public DateTime startdatetime;

        /// <summary>
        /// End timestamp
        /// </summary>
        public DateTime enddatetime;
        
        /// <summary>
        /// List of amounts and Tokens
        /// </summary>
        public List_Amounts_Tokens listamountstokens;
    }
}
