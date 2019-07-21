using System;
using System.Collections.Generic;
using System.Linq;

namespace CapsuleDotNet.Models{
    public class Case
    {
        private List<Tag> _tags;
        private List<FieldValue> _fields;
        public long Id { get; set; }
        public Party Party { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
        public Team Team { get; set; }
        public string Status { get; set; }
        public Opportunity Opportunity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string LastContactedAt { get; set; }
        public IReadOnlyCollection<Tag> Tags => _tags;
        public IReadOnlyCollection<FieldValue> Fields => _fields;
        public void AddTag(string name, string description)
        {
            if (_tags == null)
            {
                _tags = new List<Tag>(1);
            }

            _tags.Add(Tag.Create(name, description));
        }

        public void RemoveTag(long id)
        {
            if (_tags.Any(p => p.Id == id))
            {
                _tags.Remove(_tags.FirstOrDefault(p => p.Id == id));
            }
        }

        public void AddField(object value, FieldDefinition definition)
        {
            if (_fields == null)
            {
                _fields = new List<FieldValue>(1);
            }

            _fields.Add(FieldValue.Create(value, definition));
        }

        public void RemoveField(long id)
        {
            if (_fields.Any(p => p.Id == id))
            {
                _fields.Remove(_fields.FirstOrDefault(p => p.Id == id));
            }
        }
    }
}