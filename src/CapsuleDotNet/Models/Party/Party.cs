using System;
using System.Collections.Generic;
using System.Linq;
using CapsuleDotNet.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CapsuleDotNet.Models
{
    public class Party
    {
        private Party() { }

        private Party(string partyType)
        {
            this.Type = partyType;
        }

        public static Party Create(PartyType type)
        {
            return new Party(type.ToFriendlyString());
        }

        [JsonProperty("addresses")]
        private List<Address> _addresses;

        [JsonProperty("phoneNumbers")]
        private List<PhoneNumber> _phoneNumbers;

        [JsonProperty("fields")]
        private List<FieldValue> _fields;

        [JsonProperty("websites")]
        private List<Website> _websites;

        [JsonProperty("emailAddresses")]
        private List<EmailAddress> _emailAddresses;

        [JsonProperty("tags")]
        private List<Tag> _tags;

        [JsonProperty("id")]
        public long? Id { get; private set; }
    
        public string Type { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string JobTitle { get; set; }

        public Party Organisation { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public DateTime? LastContactedAt { get; private set; }

        [JsonProperty("isRestricted")]
        public bool IsRestricted { get; private set; }

        [JsonIgnore]
        public IReadOnlyCollection<Address> Addresses => _addresses;

        [JsonIgnore]
        public IReadOnlyCollection<PhoneNumber> PhoneNumbers => _phoneNumbers;

        [JsonIgnore]
        public IReadOnlyCollection<Website> Websites => _websites;

        [JsonIgnore]
        public IReadOnlyCollection<FieldValue> Fields => _fields;

        [JsonIgnore]
        public IReadOnlyCollection<EmailAddress> EmailAddresses => _emailAddresses;

        [JsonIgnore]
        public IReadOnlyCollection<Tag> Tags => _tags;

        public void AddAddress(AddressType type, string street, string city, string state, string country, string zip)
        {
            if (_addresses == null)
            {
                _addresses = new List<Address>(1);
            }

            _addresses.Add(Address.Create(type, street, city, state, country, zip));
        }

        public void RemoveAddress(long id)
        {
            if (_addresses.Any(p => p.Id == id))
            {
                _addresses.FirstOrDefault(p => p.Id == id).Delete = true;
            }
        }

        public void AddEmailAddress(EmailAddressType type, string address)
        {
            if (_emailAddresses == null)
            {
                _emailAddresses = new List<EmailAddress>(1);
            }

            _emailAddresses.Add(EmailAddress.Create(type, address));
        }

        public void RemoveEmailAddress(long id)
        {
            if (_emailAddresses.Any(p => p.Id == id))
            {
                _emailAddresses.FirstOrDefault(p => p.Id == id).Delete = true;
            }
        }
        public void AddPhoneNumber(PhoneNumberType type, string number)
        {
            if (_phoneNumbers == null)
            {
                _phoneNumbers = new List<PhoneNumber>(1);
            }

            _phoneNumbers.Add(PhoneNumber.Create(type, number));
        }

        public void RemovePhoneNumber(long id)
        {
            if (_phoneNumbers.Any(p => p.Id == id))
            {
                _phoneNumbers.FirstOrDefault(p => p.Id == id).Delete = true;
            }
        }

        public void AddWebsite(WebsiteType type, WebsiteService service, string address, string url)
        {
            if (_websites == null)
            {
                _websites = new List<Website>(1);
            }

            _websites.Add(Website.Create(type, service, address, url));
        }

        public void RemoveWebsite(long id)
        {
            if (_websites.Any(p => p.Id == id))
            {
                _websites.FirstOrDefault(p => p.Id == id).Delete = true;
            }
        }

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
                _tags.FirstOrDefault(p => p.Id == id).Delete = true;
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
                _fields.FirstOrDefault(p => p.Id == id).Delete = true;
            }
        }
    }
}