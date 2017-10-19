using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbifold_Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //Code for loading into memory an example TimeLagFunction from a dll 
           
            Assembly assembly = Assembly.LoadFrom("ExampleTimeLagFunction.dll");
            Type exampletimelagfunctiontype = assembly.GetType("ExampleTimeLagFunction.ExampleTimeFunction");
            ITimeFunction exampletimelagfunction = Activator.CreateInstance(exampletimelagfunctiontype) as ITimeFunction;

            // Sample showing exmaple time lag function changing a date. 

            DateTime startdatetime = new DateTime(2018, 3, 27);
            
            Console.WriteLine("The value of startdatetime before I called the example time function is {0}", startdatetime);

            DateTime newishdatetime = exampletimelagfunction.TimeLagFunction(startdatetime);

            Console.WriteLine("The value after I called the example time function is {0}", newishdatetime);

            // End code and sample
            
            // Expected form of code for URI lookup functionality.

            using (var client = new WebClient())
            {
                var contents = client.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=MSFT&f=l1");
                Console.WriteLine("Microsoft stock price: {0}",contents);
            }

            // Example token constructions.

            Coin_Address my_coinaddress = new Coin_Address();
            my_coinaddress.coinaddress = "text of coin address";

            Coin_Address my_other_coinaddress = new Coin_Address();
            my_other_coinaddress.coinaddress = "text of another coin address";

            List_Coin_Addresses my_listcoinaddresses = new List_Coin_Addresses();
            my_listcoinaddresses.coinaddresses.Add(my_coinaddress);
            my_listcoinaddresses.coinaddresses.Add(my_other_coinaddress);
            my_listcoinaddresses.coinaddresses.Add(my_coinaddress);

            Base_Token my_token = new Base_Token();
            my_token.coinaddress = my_coinaddress;
            my_token.description = "an example token";
            my_token.hash = "some hash";
            
            List_Token lt1 = new List_Token();

            lt1.tokens.Add(my_token);

            List_Token lt2 = new List_Token();


            List<Token> tokens = new List<Token> { my_token, my_token, my_token, my_token};

            lt2.tokens.AddRange(tokens);

            Function_Token ft = new Function_Token();
            ft.datetime = new DateTime(2016,3,25);

            ft.token = lt2;

            ft.TimeLagFunctionName = "Probably the hash of some code that defines the function";
            ft.ValueFunctionName = "Also, probably hash of some code that defines the function";

            List_Token lt3 = new List_Token();

            lt3.tokens.Add(ft);
            lt3.tokens.Add(lt1);
            
            Amount_Token_Pair pair1 = new Amount_Token_Pair();
            pair1.amount = 100;
            pair1.token = my_token;

            Amount_Token_Pair pair2 = new Amount_Token_Pair();
            pair2.amount = 200;
            pair2.token = lt3;

            Amount_Token_Pair pair3 = new Amount_Token_Pair();
            pair3.amount = 300;
            pair3.token = lt2;

            List_Amounts_Tokens mylats = new List_Amounts_Tokens();

            mylats.listamountstokens.Add(pair1);
            mylats.listamountstokens.Add(pair2);
            mylats.listamountstokens.Add(pair3);


            Console.WriteLine("The amount on first entry on my list of amount and token pairs is: " + mylats.listamountstokens[0].amount);
            Console.WriteLine("The amount on second entry on my list of amount and token pairs is: " + mylats.listamountstokens[1].amount);
            Console.WriteLine("The amount on third entry on my list of amount and token pairs is: " + mylats.listamountstokens[2].amount);


            Option_Token ot = new Option_Token();

            ot.startdatetime = new DateTime(2018, 3, 27);
            ot.enddatetime = new DateTime(2018, 3, 29);
            ot.listamountstokens = mylats;

            Security_Token st = new Security_Token();
            st.issuercoinaddress = my_coinaddress;
            st.listcoinaddresses = my_listcoinaddresses;
            st.asset = false;
            st.liability = true;
            st.token = ot;


            TokenNormaliser n = new TokenNormaliser();
            Token nt = new Token();
            Token nnt = new Token();

            nt = st;      // note that 'equals' has not been implemented on the Token class. This is false, but the XMLs are identical.

            Serialization_Helper.SerializeObject(nt, "beforenormalised.xml");

            nnt = n.NormalToken(nt);
            
            Serialization_Helper.SerializeObject(nnt, "normalised.xml");

            Console.WriteLine("normalised equals original? {0}", nnt.Equals(nt));

            Console.WriteLine("Type of original: {0}", nt.GetType());
            Console.WriteLine("Type of normalised: {0}", nnt.GetType());

            // Serialization and de-serialization examples.

            Serialization_Helper.SerializeObject(lt1, "myserializedobject1.xml");

            Serialization_Helper.SerializeObject(my_token, "mytoken.xml");

            Serialization_Helper.SerializeObject(lt1, "myserializedobject1.xml");

            Serialization_Helper.SerializeObject(lt2, "myserializedobject2.xml");

            Serialization_Helper.SerializeObject(lt3, "myserializedobject3.xml");

            var newobj = Serialization_Helper.DeSerializeObject<List_Token>("myserializedobject3.xml");

            Serialization_Helper.SerializeObject(ft, "myfunctiontoken.xml");

            Serialization_Helper.SerializeObject(ot, "optiontoken.xml");

            Serialization_Helper.SerializeObject(st, "securitytoken.xml");

            // Few final random examples.
  
            if (ft.token is List_Token)Console.WriteLine("What was defined in ft.Token at this was point is a List Token");    
        

            Console.WriteLine("How long is the deserialized token object 3: " + newobj.tokens.Count);
            Console.WriteLine("Token address: " + my_token.coinaddress.coinaddress);
            Console.WriteLine("Token description: " + my_token.description);
            Console.WriteLine("Token hash: " + my_token.hash);



            Console.WriteLine("Press key to exit");

            Console.ReadKey();
        }
    }
}
