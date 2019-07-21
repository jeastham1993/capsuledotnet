using System;
using CapsuleDotNet.Common;

namespace CapsuleDotNet.Models{
    public class Task
    {
        private Task(){}

        private Task(string description, Party party){
            this.Description = description;
            this.Party = party;
        }

        private Task(string description, Opportunity opp){
            this.Description = description;
            this.Opportunity = opp;
        }

        private Task(string description, Case caseObject){
            this.Description = description;
            this.Kase = caseObject;
        }

        public static Task Create(string description,  Party party){
            if (string.IsNullOrEmpty(description)){
                throw new ArgumentException("Description cannot be null or empty");
            }

            return new Task(description, party);
        }

        public static Task Create(string description,  Case caseObject){
            if (string.IsNullOrEmpty(description)){
                throw new ArgumentException("Description cannot be null or empty");
            }
            
            return new Task(description, caseObject);
        }

        public static Task Create(string description,  Opportunity opp){
            if (string.IsNullOrEmpty(description)){
                throw new ArgumentException("Description cannot be null or empty");
            }
            
            return new Task(description, opp);
        }
        public long Id { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public Category Category { get; set; }
        public DateTime? DueOn { get; set; }
        public string DueTime { get; set; }
        public Status? Status { get; set; }
        public Party Party { get; private set; }
        public Opportunity Opportunity { get; private set; }
        public Case Kase { get; private set; }
        public User Owner { get; set; }
        public string CompletedBy { get; private set; }
        public string CompletedAt { get; set; }
        public TaskRepeat Repeat { get; private set; }
        public Boolean? HasTrack { get; set; }
        public Task NextTask { get; set; }
        public TaskDelayRule TaskDelayRule { get; set; }
        public int? DaysAfter { get; set; }

        public void SetTaskRepeat(TaskRepeatFrequency frequency, int interval, string on){
            if (this.Repeat == null){
                this.Repeat = TaskRepeat.Create(frequency, interval, on);
            }
            else{
                this.Repeat.Update(frequency, interval, on);
            }
        }
    
        public void SetParty(Party p){
            if (this.Kase != null || this.Opportunity != null){
                throw new ArgumentException("Only one of kase, opportunity and party can be populated");
            }
            
            this.Party = p;
        }

        public void SetOpportunity(Opportunity o){
            if (this.Kase != null || this.Party != null){
                throw new ArgumentException("Only one of kase, opportunity and party can be populated");
            }
            
            this.Opportunity = o;
        }

        public void SetKase(Case c){
            if (this.Party != null || this.Opportunity != null){
                throw new ArgumentException("Only one of kase, opportunity and party can be populated");
            }
            
            this.Kase = c;
        }
    }
}