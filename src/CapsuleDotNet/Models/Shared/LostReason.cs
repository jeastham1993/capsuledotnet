using System;

namespace CapsuleDotNet.Models{
    public class LostReason
    {
        private LostReason(){}
        private LostReason(string name, bool includedForConversion){
            this.Name = name;
            this.IncludedForConversion = includedForConversion;
        }

        public static LostReason Create(string name, bool includedForConversion){
            if (string.IsNullOrEmpty(name)){
                throw new ArgumentException("Name cannot be null or empty");
            }

            return new LostReason(name, includedForConversion); 
        }
        public long? Id { get; private set; }

        public string Name { get; set; }

        public bool IncludedForConversion { get; set; }
    }
}