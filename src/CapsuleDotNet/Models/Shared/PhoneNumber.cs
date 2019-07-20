using System;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class PhoneNumber{
        public static PhoneNumber Create(PhoneNumberType type, string number){
            if (string.IsNullOrEmpty(number)){
                throw new ArgumentException("Number must be populated");
            }

            return new PhoneNumber(){
                Type = nameof(type),
                Number = number
            };
        }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }
        
        [JsonProperty]
        public string Number { get; private set; }
    }
}