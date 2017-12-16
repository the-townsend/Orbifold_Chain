using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    /// <summary>
    /// NormalToken: Takes a token and (i) puts any list component to the front and (ii) collapses any multiple security token (security token whose
    /// underlying token is a security token, etc) into a single security token. Done recursively so that the underlying token(s)
    /// of any normalised Token is either a base Token, Function Token, Option Token or Security Token. Returns a Token or Null. 
    /// NormalListToken etc: applies to specific Token clases (e.g. List_Token) as part of the recursive definition of NormalToken. 
    /// </summary>
    public class TokenNormaliser
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
            List_Token return_value = null;
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
            return_value = newnormallisttoken;

            return return_value;
        }
        public Token NormalFunctionToken(Function_Token functiontoken)
        {
            Token return_value = null;
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
                    newfunctiontoken.ValueFunctionName = functiontoken.ValueFunctionName;
                    newfunctiontoken.TimeLagFunctionName = functiontoken.TimeLagFunctionName;
                    newnormallisttoken.tokens.Add(newfunctiontoken);
                }
                return_value = newnormallisttoken;
            }
            else
            {
                var newfunctiontoken = new Function_Token();
                newfunctiontoken.amount = functiontoken.amount;
                newfunctiontoken.datetime = functiontoken.datetime;
                newfunctiontoken.token = normaltoken;
                newfunctiontoken.ValueFunctionName = functiontoken.ValueFunctionName;
                newfunctiontoken.TimeLagFunctionName = functiontoken.TimeLagFunctionName;
                return_value = newfunctiontoken;
            }

            return return_value;
        }
        public Token NormalSecurityToken(Security_Token securitytoken)
        {
            Token return_value = null;
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
                    newsecuritytoken = NormalSecurityToken(newsecuritytoken) as Security_Token;
                    newnormallisttoken.tokens.Add(newsecuritytoken);
                }
                return_value = newnormallisttoken;
            }
            else
            {
                if (normaltoken is Security_Token)
                {
                    var normalsecuritytoken = normaltoken as Security_Token;
                    Security_Token newnormalsecuritytoken = new Security_Token();
                    newnormalsecuritytoken.issuercoinaddress = normalsecuritytoken.issuercoinaddress;

                    if(!securitytoken.listcoinaddresses.coinaddresses.Except(normalsecuritytoken.listcoinaddresses.coinaddresses).Any())
                    {
                        newnormalsecuritytoken.listcoinaddresses = securitytoken.listcoinaddresses;    // Takes onward transfer restriction list of addresses from parent
                    }
                    else
                    {
                        throw new Exception("Security Token cannot add addresses allowable for onward transfer to those addresses given in child Security");
                    }

                    newnormalsecuritytoken.asset = normalsecuritytoken.asset;
                    newnormalsecuritytoken.liability = normalsecuritytoken.liability;
                    newnormalsecuritytoken.token = normalsecuritytoken.token;
                   
                    return_value = newnormalsecuritytoken;
                }
                else
                {
                    Security_Token newnormalsecuritytoken = new Security_Token();
                    newnormalsecuritytoken.issuercoinaddress = securitytoken.issuercoinaddress;
                    newnormalsecuritytoken.listcoinaddresses = securitytoken.listcoinaddresses;  
                    newnormalsecuritytoken.asset = securitytoken.asset;
                    newnormalsecuritytoken.liability = securitytoken.liability;
                    newnormalsecuritytoken.token = normaltoken;  
                    
                    return_value = newnormalsecuritytoken;
                }
            }
            return return_value;
        }
    }
}
