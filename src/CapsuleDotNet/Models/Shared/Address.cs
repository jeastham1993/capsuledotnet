using System;
using System.Linq;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class Address
    {
        private Address(){}

        internal static Address Create(AddressType type, string street, string city, string state, string country, string zip){

            if (country == null || Countries.CountryList.Any(p => p == country) == false) {
                throw new ArgumentException($"Invalid country {country}");
            }
            
            var newAddress = new Address();
            newAddress.Type = nameof(type);
            newAddress.Street = street;
            newAddress.City = city;
            newAddress.State = state;
            newAddress.Country = country;
            newAddress.Zip = zip;

            return newAddress;
        }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }

        [JsonProperty]
        public string Street { get; private set; }

        [JsonProperty]
        public string City { get; private set; }

        [JsonProperty]
        public string State { get; private set; }

        [JsonProperty]
        public string Country { get; private set; }

        [JsonProperty]
        public string Zip { get; private set; }
    }
}