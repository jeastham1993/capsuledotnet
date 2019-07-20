using System;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class Tag{
        public static Tag Create(string name, string description){
            if (string.IsNullOrEmpty(name)){
                throw new ArgumentException("Name must be populated");
            }

            return new Tag(){
                Name = name,
                Description = description
            };
        }

        [JsonProperty]
        public long Id { get; private set; }
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }
    }
}