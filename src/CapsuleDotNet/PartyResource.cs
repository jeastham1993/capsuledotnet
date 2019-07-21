using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;

namespace CapsuleDotNet
{
    public static class PartyResource
    {
        static PartyResource(){
            if (CapsuleClient._isInit == false){
                throw new Exception("Capsule client must first be initialised with a valid API key");
            }
        }
        
        private const string BASE_ENDPOINT = "parties";

        public static Party Create(Party party)
        {
            return PartyResource.CreateAsync(party).Result;
        }

        public async static Task<Party> CreateAsync(Party party)
        {
            var wrapperObject = PartyWrapper.Load(party);

            var response = await CapsuleClient.makeRequest<PartyWrapper>(BASE_ENDPOINT,
                "POST",
                wrapperObject);

            return response.Party;
        }
        
        public static Party Update(long partyId, Party party)
        {
            return PartyResource.UpdateAsync(partyId, party).Result;
        }

        public async static Task<Party> UpdateAsync(long partyId, Party party)
        {
            var wrapperObject = PartyWrapper.Load(party);

            var response = await CapsuleClient.makeRequest<PartyWrapper>($"{BASE_ENDPOINT}/{partyId}",
                "PUT",
                wrapperObject);

            return response.Party;
        }

        public static bool Delete(long partyId){
            return PartyResource.DeleteAsync(partyId).Result;
        }

        public async static Task<bool> DeleteAsync(long partyId){
            var response = await CapsuleClient.makeRequest<PartyWrapper>($"{BASE_ENDPOINT}/{partyId}", "DELETE");

            return true;
        }

        public static PartyWrapper List(DateTime? since = null, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            return PartyResource.ListAsync(since, page, perPage, embed).Result;
        }

        public async static Task<PartyWrapper> ListAsync(DateTime? since = null, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            var parties = await CapsuleClient.baseGetRequest<PartyWrapper>(BASE_ENDPOINT, since, page, perPage, embed);

            return parties;
        }

        public static Party Show(string partyId, Embed[] embed = null)
        {
            return PartyResource.ShowAsync(partyId, embed).Result;
        }

        public async static Task<Party> ShowAsync(string partyId, Embed[] embed = null)
        {
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{partyId}");

            if (embed != null)
            {
                endpoint.Append($"?embed={String.Join(",", embed)}");
            }

            var party = await CapsuleClient.makeRequest<PartyWrapper>(endpoint.ToString(), "get");

            return party.Party;
        }

        public static PartyWrapper ShowMultiple(string[] partyIds, Embed[] embed = null)
        {
            return PartyResource.ShowMultipleAsync(partyIds, embed).Result;
        }

        public async static Task<PartyWrapper> ShowMultipleAsync(string[] partyIds, Embed[] embed = null)
        {
            if (partyIds.Length > 10)
            {
                throw new ArgumentException("A max of 10 party id's can be sent at any one time");
            }

            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{string.Join(",", partyIds)}");

            if (embed != null)
            {
                endpoint.Append($"?embed={String.Join(",", embed)}");
            }

            var party = await CapsuleClient.makeRequest<PartyWrapper>(endpoint.ToString(), "get");

            return party;
        }
    }
}