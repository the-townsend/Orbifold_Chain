using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    /// <summary>
    /// Takes a token and (i) puts any list component to the front and (ii) collapses any multiple security token (security token whose
    /// underlying token is a security token, etc) into a single security token. Done recursively so that the underlying token(s)
    /// of any normalised Token is either a base Token, Function Token, Option Token or Security Token. 
    /// </summary>
    class TokenNormaliser
    {
        public Token NormalToken(Token token)
        {
            Token return_value = null;

            if (token is Base_Token)
            {
                return_value = token;
            }
            if (token is List_Token)
            {                
                return_value = NormalListToken(token as List_Token);
            }
            if (token is Function_Token)
            {
                return_value = NormalFunctionToken(token as Function_Token);
            }
            if (token is Option_Token)
            {
                return_value = token;
            }
            if (token is Security_Token)
            {
                return_value = NormalSecurityToken(token as Security_Token);
            }

            if(return_value == null)
            {
                throw new Exception("In method NormalToken, unrecognised token type");
            }

            return return_value;   
        }
        public List_Token NormalListToken(List_Token listtoken)
        {
            List_Token newnormallisttoken = new List_Token();
            for (int i = 0; i < listtoken.tokens.Count; i++)
            {
                Token normaltoken = NormalToken(listtoken.tokens[i]);
                if (normaltoken is List_Token)
                {
                    var normallisttoken = normaltoken as List_Token;
                    for (int j = 0; j < normallisttoken.tokens.Count; j++)
                    {
                        newnormallisttoken.tokens.Add(normallisttoken.tokens[j]);
                    }
                }
                else
                {
                    newnormallisttoken.tokens.Add(normaltoken);
                }
            }
            return newnormallisttoken;
        }
        public Token NormalFunctionToken(Function_Token functiontoken)
        {
            Token normaltoken = NormalToken(functiontoken.token);
            if (normaltoken is List_Token)
            {
                var normallisttoken = normaltoken as List_Token;
                List_Token newnormallisttoken = new List_Token();
                for (int i = 0; i < normallisttoken.tokens.Count; i++)
                {
                    var newfunctiontoken = new Function_Token();
                    newfunctiontoken.amount = functiontoken.amount;
                    newfunctiontoken.datetime = functiontoken.datetime;
                    newfunctiontoken.token = normallisttoken.tokens[i];
                    //
                    // **** Function and Lag elements are missing *****
                    //
                    newnormallisttoken.tokens.Add(newfunctiontoken);
                }
                return newnormallisttoken;
            }
            else
            {
                var newfunctiontoken = new Function_Token();
                newfunctiontoken.amount = functiontoken.amount;
                newfunctiontoken.datetime = functiontoken.datetime;
                newfunctiontoken.token = normaltoken;
                //
                // **** Function and Lag elements are missing *****
                //
                return newfunctiontoken;
            }
        }
        public Token NormalSecurityToken(Security_Token securitytoken)
        {
            Token normaltoken = NormalToken(securitytoken.token);
            if (normaltoken is List_Token)
            {
                var normallisttoken = normaltoken as List_Token;
                List_Token newnormallisttoken = new List_Token();
                for (int i = 0; i < normallisttoken.tokens.Count; i++)
                {
                    var newsecuritytoken = new Security_Token();
                    newsecuritytoken.issuercoinaddress = securitytoken.issuercoinaddress;
                    newsecuritytoken.listcoinaddresses = securitytoken.listcoinaddresses;
                    newsecuritytoken.asset = securitytoken.asset;
                    newsecuritytoken.liability = securitytoken.liability;
                    newsecuritytoken.token = normallisttoken.tokens[i];
                    newnormallisttoken.tokens.Add(newsecuritytoken);
                }
                return newnormallisttoken;
            }
            else
            {
                var newsecuritytoken = new Security_Token();
                newsecuritytoken.issuercoinaddress = securitytoken.issuercoinaddress;
                newsecuritytoken.listcoinaddresses = securitytoken.listcoinaddresses;
                newsecuritytoken.asset = securitytoken.asset;
                newsecuritytoken.liability = securitytoken.liability;
                newsecuritytoken.token = normaltoken;
                return newsecuritytoken;
            }
        }
    }
}
