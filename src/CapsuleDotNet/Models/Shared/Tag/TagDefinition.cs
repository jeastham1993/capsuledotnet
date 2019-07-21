using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class TagDefinition
    {
        [JsonProperty("definitions")]
        private List<FieldDefinition> _definitions;

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; set; }

        public bool DataTag { get; set; }

        [JsonIgnore]
        public IReadOnlyCollection<FieldDefinition> Definitions => _definitions;

        public void AddFieldDefinition(FieldDefinition definition){
            if (definition == null){
                throw new ArgumentException("Definition cannot be null");
            }

            if (_definitions == null){
                _definitions = new List<FieldDefinition>(1);
            }

            if (_definitions.Any(p => p == definition) == false){
                _definitions.Add(definition);
            }
        }

        public void RemoveFieldDefinition(long id){
            if (_definitions != null && _definitions.Any(p => p.Id == id)){
                _definitions.Remove(_definitions.FirstOrDefault(p => p.Id == id));
            }
        }
    }
}