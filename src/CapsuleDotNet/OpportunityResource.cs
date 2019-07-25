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

    }
}