﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{ 
    /// <summary>
    /// Function Token consists of an amount(x), a time point(t), a Token, a value function and a time lag function. 
    /// Token pays out x times function(t) at point in time timelag(t). 
    /// </summary>
    [Serializable]
    public class Function_Token:Token
    {
        
        /// <summary>
        /// An amount  
        /// </summary>
        public Double amount;

        /// <summary>
        /// A timestamp
        /// </summary>
        public DateTime datetime;

        /// <summary>
        /// Underlying Token
        /// </summary>
        public Token token;

        /// <summary>
        /// The identifier string of a value function
        /// </summary>
        public string ValueFunctionName { get; set; }

        /// <summary>
        /// The identifier string of a value function
        /// </summary>
        public string TimeLagFunctionName { get; set; }

    }
}
