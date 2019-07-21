using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class FieldDefinition{

        [JsonProperty]
        public long? Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }
    }
}