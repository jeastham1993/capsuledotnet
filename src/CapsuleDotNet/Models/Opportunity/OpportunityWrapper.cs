using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class OpportunityWrapper : DefaultObjectWrapper
    {
        private OpportunityWrapper(){}

        private OpportunityWrapper(Opportunity Opportunity){
            this.Opportunity = Opportunity;
            this.Opportunities = null;
        }

        public static OpportunityWrapper Load(Opportunity Opportunity){
            if (Opportunity == null){
                throw new ArgumentException("Opportunity cannot be null");
            }

            return new OpportunityWrapper(Opportunity);
        }

        [JsonProperty("opportunities")]
        public IEnumerable<Opportunity> Opportunities {get; set;}

        [JsonProperty("opportunity")]
        public Opportunity Opportunity {get; set;}
    }
}