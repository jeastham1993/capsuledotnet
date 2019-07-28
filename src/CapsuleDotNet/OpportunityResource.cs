using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;

namespace CapsuleDotNet
{
    public static class OpportunityResource
    {
        static OpportunityResource()
        {
            CapsuleClient.IsInit();
        }

        private const string BASE_ENDPOINT = "opportunities";

        public static OpportunityWrapper List(DateTime? since = null, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            return OpportunityResource.ListAsync(since, page, perPage, embed).Result;
        }

        public async static Task<OpportunityWrapper> ListAsync(DateTime? since = null, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            var opportunities = await CapsuleClient.baseGetRequest<OpportunityWrapper>(BASE_ENDPOINT, since, page, perPage, embed);

            return opportunities;
        }

        public static OpportunityWrapper ListByParty(long partyId, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            return OpportunityResource.ListByPartyAsync(partyId, page, perPage, embed).Result;
        }

        public async static Task<OpportunityWrapper> ListByPartyAsync(long partyId, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            var endpoint = $"{BASE_ENDPOINT}/{partyId}/opportunities";

            var opportunities = await CapsuleClient.baseGetRequest<OpportunityWrapper>(BASE_ENDPOINT, null, page, perPage, embed);

            return opportunities;
        }

        public static Opportunity Show(long opportunityId, Embed[] embed = null)
        {
            return OpportunityResource.ShowAsync(opportunityId, embed).Result;
        }

        public async static Task<Opportunity> ShowAsync(long opportunityId, Embed[] embed = null)
        {
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{opportunityId}");

            if (embed != null)
            {
                endpoint.Append($"?embed={String.Join(",", embed)}");
            }

            var apiResponse = await CapsuleClient.makeRequest<OpportunityWrapper>(endpoint.ToString(), "get");

            return apiResponse.Opportunity;
        }

        public static OpportunityWrapper ShowMultiple(long[] opportunityIds, Embed[] embed = null)
        {
            return OpportunityResource.ShowMultipleAsync(opportunityIds, embed).Result;
        }

        public async static Task<OpportunityWrapper> ShowMultipleAsync(long[] opportunityIds, Embed[] embed = null)
        {
            if (opportunityIds.Length > 10)
            {
                throw new ArgumentException("A max of 10 opportunity id's can be sent at any one time");
            }

            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{string.Join(",", opportunityIds)}");

            if (embed != null)
            {
                endpoint.Append($"?embed={String.Join(",", embed)}");
            }

            var opportunity = await CapsuleClient.makeRequest<OpportunityWrapper>(endpoint.ToString(), "get");

            return opportunity;
        }

        public static Opportunity Create(Opportunity opportunity)
        {
            return OpportunityResource.CreateAsync(opportunity).Result;
        }

        public async static Task<Opportunity> CreateAsync(Opportunity opportunity)
        {
            var wrapperObject = OpportunityWrapper.Load(opportunity);

            var response = await CapsuleClient.makeRequest<OpportunityWrapper>(BASE_ENDPOINT,
                "POST",
                wrapperObject);

            return response.Opportunity;
        }

        public static Opportunity Update(long opportunityId, Opportunity opportunity)
        {
            return OpportunityResource.UpdateAsync(opportunityId, opportunity).Result;
        }

        public async static Task<Opportunity> UpdateAsync(long opportunityId, Opportunity opportunity)
        {
            // Duration bases cannot be updated
            opportunity.DurationBasis = null;

            var wrapperObject = OpportunityWrapper.Load(opportunity);

            var response = await CapsuleClient.makeRequest<OpportunityWrapper>($"{BASE_ENDPOINT}/{opportunityId}",
                "PUT",
                wrapperObject);

            return response.Opportunity;
        }

        public static bool Delete(long opportunityId)
        {
            return OpportunityResource.DeleteAsync(opportunityId).Result;
        }

        public async static Task<bool> DeleteAsync(long opportunityId)
        {
            var response = await CapsuleClient.makeRequest<OpportunityWrapper>($"{BASE_ENDPOINT}/{opportunityId}", "DELETE");

            return true;
        }

        public static OpportunityWrapper ListDeleted(DateTime since)
        {
            return OpportunityResource.ListDeletedAsync(since).Result;
        }

        public async static Task<OpportunityWrapper> ListDeletedAsync(DateTime since)
        {
            var deletedOpportunities = await CapsuleClient.makeRequest<OpportunityWrapper>($"{BASE_ENDPOINT}/deleted?since={since.ToString("yyyy/MM/dd")}", "GET");

            return deletedOpportunities;
        }

        public static OpportunityWrapper SearchOpportunities(string query, int page = 1, int perPage = 20)
        {
            return OpportunityResource.SearchOpportunitiesAsync(query, page, perPage).Result;
        }

        public async static Task<OpportunityWrapper> SearchOpportunitiesAsync(string query, int page = 1, int perPage = 20)
        {
            var endpoint = $"{BASE_ENDPOINT}/search?q={query}&page={page}&perPage={perPage}";

            var foundOpportunities = await CapsuleClient.makeRequest<OpportunityWrapper>(endpoint, "GET");

            return foundOpportunities;
        }
    
        public static PartyWrapper ListAdditionalParties(long opportunityId, int page = 1, int perPage = 20, Embed[] embed = null){
            return OpportunityResource.ListAdditionalPartiesAsync(opportunityId, page, perPage, embed).Result;
        }

        public async static Task<PartyWrapper> ListAdditionalPartiesAsync(long opportunityId, int page = 1, int perPage = 20, Embed[] embed = null){
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{opportunityId}/parties?page={page}&perPage={perPage}");

            if (embed != null)
            {
                endpoint.Append($"?embed={String.Join(",", embed)}");
            }

            var apiResponse = await CapsuleClient.makeRequest<PartyWrapper>(endpoint.ToString(), "GET");

            return apiResponse;
        }

        public static bool AddAdditionalParty(long opportunityId,long partyId){ 
            return OpportunityResource.AddAdditionalPartyAsync(opportunityId, partyId).Result;
        }
    
        public async static Task<bool> AddAdditionalPartyAsync(long opportunityId,long partyId){ 
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{opportunityId}/parties/{partyId}");

            var apiResponse = await CapsuleClient.makeRequest(endpoint.ToString(), "POST");

            return apiResponse;
        }

        public static bool RemoveAdditionalParty(long opportunityId,long partyId){ 
            return OpportunityResource.RemoveAdditionalPartyAsync(opportunityId, partyId).Result;
        }
    
        public async static Task<bool> RemoveAdditionalPartyAsync(long opportunityId,long partyId){ 
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{opportunityId}/parties/{partyId}");

            var apiResponse = await CapsuleClient.makeRequest(endpoint.ToString(), "DELETE");

            return apiResponse;
        }
        
        public static CaseWrapper ListAssociatedCases(long opportunityId, int page = 1, int perPage = 20, Embed[] embed = null){
            return OpportunityResource.ListAssociatedCasesAsync(opportunityId, page, perPage, embed).Result;
        }
   
        public async static Task<CaseWrapper> ListAssociatedCasesAsync(long opportunityId, int page = 1, int perPage = 20, Embed[] embed = null){ 
            var endpoint = new StringBuilder($"{BASE_ENDPOINT}/{opportunityId}/kases?page={page}&perPage={perPage}");

            if (embed != null)
            {
                endpoint.Append($"?embed={String.Join(",", embed)}");
            }

            var apiResponse = await CapsuleClient.makeRequest<CaseWrapper>(endpoint.ToString(), "GET"); //

            return apiResponse;
        }
    }
}