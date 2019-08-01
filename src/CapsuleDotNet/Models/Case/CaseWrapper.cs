using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class CaseWrapper : DefaultObjectWrapper
    {
        private CaseWrapper(){}

        private CaseWrapper(Case caseObject){
            this.Case = caseObject;
            this.Cases = null;
        }

        public static CaseWrapper Load(Case caseObject){
            if (caseObject == null){
                throw new ArgumentException("Case cannot be null");
            }

            return new CaseWrapper(caseObject);
        }

        [JsonProperty("kases")]
        public IEnumerable<Case> Cases {get; set;}

        [JsonProperty("kase")]
        public Case Case {get; set;}
    }
}