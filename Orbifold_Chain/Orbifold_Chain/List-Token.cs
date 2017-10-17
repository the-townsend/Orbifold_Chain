using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    [Serializable]

    public class List_Token :Token
    {
        public List_Token()
        {
            tokens = new List<Token>();
        }

        public List<Token> tokens;
    }
}
