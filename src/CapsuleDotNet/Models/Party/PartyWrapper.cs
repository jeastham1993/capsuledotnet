using System.Collections.Generic;
using System.Threading.Tasks;
using CapsuleDotNet.Common;

namespace CapsuleDotNet.Models{
    public class PartyWrapper : DefaultObjectWrapper
    {
        public List<Party> Parties {get; set;}

        public Party Party {get; set;}
    }
}