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

    }
}