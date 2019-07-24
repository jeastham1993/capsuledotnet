using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class PartyWrapper : DefaultObjectWrapper
    {
        private PartyWrapper(){}

        private PartyWrapper(Party party){
            this.Party = party;
            this.Parties = null;
        }

        public static PartyWrapper Load(Party party){
            if (party == null){
                throw new ArgumentException("Party cannot be null");
            }

            return new PartyWrapper(party);
        }

        [JsonProperty("parties")]
        public IEnumerable<Party> Parties {get; set;}

        [JsonProperty("party")]
        public Party Party {get; set;}
    }
}