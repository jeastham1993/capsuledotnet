using System;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class EmailAddress{
        public static EmailAddress Create(EmailAddressType type, string address){
            if (string.IsNullOrEmpty(address)){
                throw new ArgumentException("Address must be populated");
            }

            return new EmailAddress(){
                Type = nameof(type),
                Address = address
            };
        }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Address { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }
    }
}