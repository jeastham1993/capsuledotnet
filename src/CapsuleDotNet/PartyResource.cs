using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;

namespace CapsuleDotNet{
    public static class PartyResource
    {
        private const string BASE_ENDPOINT = "parties";

        public async static Task<PartyWrapper> GetAsync(DateTime? since = null, int page = 1, int perPage = 20, EmbedEnum[] embed = null){
            var parties = await CapsuleClient.baseGetRequest<PartyWrapper>(BASE_ENDPOINT, since, page, perPage, embed);

            return parties;
        }

        public async static Task<Party> GetSpecificAsync(string partyId, EmbedEnum[] embed = null){
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{partyId}");

            if (embed !=null){
                endpoint.Append($"?embed={String.Join(",", embed)}");
            }

            var party = await CapsuleClient.makeRequest<PartyWrapper>(endpoint.ToString(), "get");

            return party.Party;
        }
    }
}