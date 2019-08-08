using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;

namespace CapsuleDotNet
{
    public static class CaseResource
    {
        static CaseResource()
        {
            CapsuleClient.IsInit();
        }

        private const string BASE_ENDPOINT = "kases";

        public static Case Create(Case party)
        {
            return CaseResource.CreateAsync(party).Result;
        }

        public async static Task<Case> CreateAsync(Case party)
        {
            var wrapperObject = CaseWrapper.Load(party);

            var response = await CapsuleClient.makeRequest<CaseWrapper>(BASE_ENDPOINT,
                "POST",
                wrapperObject);

            return response.Case;
        }

        public static Case Update(long partyId, Case party)
        {
            return CaseResource.UpdateAsync(partyId, party).Result;
        }

        public async static Task<Case> UpdateAsync(long partyId, Case party)
        {
            var wrapperObject = CaseWrapper.Load(party);

            var response = await CapsuleClient.makeRequest<CaseWrapper>($"{BASE_ENDPOINT}/{partyId}",
                "PUT",
                wrapperObject);

            return response.Case;
        }

        public static bool Delete(long partyId)
        {
            return CaseResource.DeleteAsync(partyId).Result;
        }

        public async static Task<bool> DeleteAsync(long partyId)
        {
            var response = await CapsuleClient.makeRequest<CaseWrapper>($"{BASE_ENDPOINT}/{partyId}", "DELETE");

            return true;
        }

        public static CaseWrapper List(DateTime? since = null, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            return CaseResource.ListAsync(since, page, perPage, embed).Result;
        }

        public async static Task<CaseWrapper> ListAsync(DateTime? since = null, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            var kases = await CapsuleClient.baseGetRequest<CaseWrapper>(BASE_ENDPOINT, since, page, perPage, embed);

            return kases;
        }

        public static CaseWrapper ListDeleted(DateTime since){
            return CaseResource.ListDeletedAsync(since).Result;
        }

        public async static Task<CaseWrapper> ListDeletedAsync(DateTime since)
        {
            var deletedCases = await CapsuleClient.makeRequest<CaseWrapper>($"{BASE_ENDPOINT}/deleted?since={since.ToString("yyyy/MM/dd")}", "GET");

            return deletedCases;
        }

        public static CaseWrapper SearchCases(string query, int page = 1, int perPage = 20){
            return CaseResource.SearchCasesAsync(query, page, perPage).Result;
        }

        public async static Task<CaseWrapper> SearchCasesAsync(string query, int page = 1, int perPage = 20){
            var endpoint = $"{BASE_ENDPOINT}/search?q={query}&page={page}&perPage={perPage}";

            var foundCases = await CapsuleClient.makeRequest<CaseWrapper>(endpoint, "GET");

            return foundCases;
        }

        public static Case Show(long partyId, Embed[] embed = null)
        {
            return CaseResource.ShowAsync(partyId, embed).Result;
        }

        public async static Task<Case> ShowAsync(long partyId, Embed[] embed = null)
        {
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{partyId}");

            if (embed != null)
            {
                endpoint.Append($"?embed={String.Join(",", embed)}");
            }

            var party = await CapsuleClient.makeRequest<CaseWrapper>(endpoint.ToString(), "get");

            return party.Case;
        }

        public static PartyWrapper ListAdditionalParties(long caseId, int page = 1, int perPage = 20, Embed[] embed = null){
            return CaseResource.ListAdditionalPartiesAsync(caseId, page, perPage, embed).Result;
        }

        public async static Task<PartyWrapper> ListAdditionalPartiesAsync(long caseId, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{caseId}/parties?page={page}&perPage={perPage}");

            if (embed != null)
            {
                endpoint.Append($"&embed={String.Join(",", embed)}");
            }

            var parties = await CapsuleClient.makeRequest<PartyWrapper>(endpoint.ToString(), "get");

            return parties;
        }

        public static bool AddAdditionalParty(long caseId, long partyId)
        {
            return CaseResource.AddAdditionalPartyAsync(caseId, partyId).Result;
        }

        public async static Task<bool> AddAdditionalPartyAsync(long caseId, long partyId)
        {
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{caseId}/parties/{partyId}");

            return await CapsuleClient.makeRequest(endpoint.ToString(), "post");;
        }

        public static CaseWrapper ShowMultiple(string[] partyIds, Embed[] embed = null)
        {
            return CaseResource.ShowMultipleAsync(partyIds, embed).Result;
        }

        public async static Task<CaseWrapper> ShowMultipleAsync(string[] partyIds, Embed[] embed = null)
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

            var party = await CapsuleClient.makeRequest<CaseWrapper>(endpoint.ToString(), "get");

            return party;
        }
    }
}