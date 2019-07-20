using System;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class FieldValue{
        public static FieldValue Create(object value, FieldDefinition definition){
            return new FieldValue(){
                Value = value,
                Definition = definition
            };
        }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public object Value { get; private set; }

        [JsonProperty]
        public FieldDefinition Definition { get; private set; }
    }
}