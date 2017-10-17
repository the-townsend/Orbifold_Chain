using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    /// <summary>
    /// Security Token consists of (i) a coin address (issuer), (ii) a list of coin addresses acceptable for onward transfer,
    /// (iii) A flag for whether it is strictly an asset, (iv) a flag for whether it is strictly a liability; and, 
    /// (v) an underlying Token
    /// </summary>
    [Serializable]
    public class Security_Token:Token
    {
        /// <summary>
        /// Issuer address  
        /// </summary>
        public Coin_Address issuercoinaddress;

        /// <summary>
        /// Addresses acceptable for onward transfer 
        /// </summary>
        public List_Coin_Addresses listcoinaddresses;

        /// <summary>
        /// Strictly asset flag
        /// </summary>
        public Boolean asset;

        /// <summary>
        /// Strictly liability flag
        /// </summary>
        public Boolean liability;

        /// <summary>
        /// Underlying token
        /// </summary>
        public Token token; 
    }
}
