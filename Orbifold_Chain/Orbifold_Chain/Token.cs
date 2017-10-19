using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Orbifold_Chain
{
    [XmlInclude(typeof(Base_Token))]
    [XmlInclude(typeof(List_Token))]
    [XmlInclude(typeof(Function_Token))]
    [XmlInclude(typeof(Example_Function_Token))]
    [XmlInclude(typeof(Option_Token))]
    [Serializable]
    public class Token
    {
    }
}
