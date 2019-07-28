using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class MilestoneWrapper : DefaultObjectWrapper
    {
        private MilestoneWrapper(){}

        private MilestoneWrapper(Milestone Milestone){
            this.Milestone = Milestone;
            this.Milestones = null;
        }

        public static MilestoneWrapper Load(Milestone Milestone){
            if (Milestone == null){
                throw new ArgumentException("Milestone cannot be null");
            }

            return new MilestoneWrapper(Milestone);
        }

        [JsonProperty("milestones")]
        public IEnumerable<Milestone> Milestones {get; set;}

        [JsonProperty("milestone")]
        public Milestone Milestone {get; set;}
    }
}