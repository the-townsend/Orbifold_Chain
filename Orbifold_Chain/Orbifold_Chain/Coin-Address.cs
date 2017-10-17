using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    [Serializable]
    public class Coin_Address
    {
        public string coinaddress;    // issuer address   
    }
    public class List_Coin_Addresses
    {
        public List_Coin_Addresses()
        {
            coinaddresses = new List<Coin_Address>();
        }

        public List<Coin_Address> coinaddresses;
    }
}
