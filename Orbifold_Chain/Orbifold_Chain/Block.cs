using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    /// <summary>
    /// A block consists of a list or (value,Token) pairs a buyer(receiver) coin-address and a seller(payer) coin-address,
    /// flags for coin-address failure and trade status (Booked, Cancelled or Pending).  
    /// </summary>
    [Serializable]
    public class Block
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime datetime;

        /// <summary>
        /// List of pairs (amounts,Tokens)  
        /// </summary>
        public List_Amounts_Tokens listamountstokens;

        /// <summary>
        /// Buyer(receiver) coin-address
        /// </summary>
        public Coin_Address buyercoinaddress;

        /// <summary>
        /// Seller(payer) coin-address
        /// </summary>
        public Coin_Address sellercoinaddress;

        /// <summary>
        /// Buyer fail flag
        /// </summary>
        public Boolean buyerfail;

        /// <summary>
        /// Seller fail flag
        /// </summary>
        public Boolean sellerfail;

        /// <summary>
        /// Trade statusSeller fail flag
        /// </summary>
        public enum TransactionStatus {Booked, Cancelled, Pending};


    }
}
