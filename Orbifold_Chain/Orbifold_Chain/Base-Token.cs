using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    [Serializable]
    public class Base_Token:Token
    {
        public Coin_Address coinaddress;    // Base token issuer address
        public string description;    // Description e.g. ''Pay bearer one USD''
        public string hash; // Hash of legal text defining Token.
        
    }
}
