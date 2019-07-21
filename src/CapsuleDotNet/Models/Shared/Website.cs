using System;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models
{
    public class Website
    {
        public static Website Create(WebsiteType type, WebsiteService service, string address, string url)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException("Address must be populated");
            }

            return new Website()
            {
                Service = service.ToFriendlyString(),
                Type = type.ToFriendlyString(),
                Address = address,
                Url = url
            };
        }

        [JsonProperty]
        public long? Id { get; private set; }

        [JsonProperty]
        public string Service { get; private set; }

        [JsonProperty]
        public string Address { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }

        [JsonProperty]
        public string Url { get; private set; }

        [JsonProperty("_delete")]
        public bool Delete { get; set; }
    }
}