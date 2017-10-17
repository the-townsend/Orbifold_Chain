using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    /// <summary>
    /// List of pairs: (amounts(double),token). 
    /// </summary>
    [Serializable]
    public class Amount_Token_Pair
    {
            public double amount;
            public Token token;
    }
    public class List_Amounts_Tokens
    {

        public List_Amounts_Tokens()
        {
            listamountstokens = new List<Amount_Token_Pair>();
        }
        public List<Amount_Token_Pair> listamountstokens;

    }
}
