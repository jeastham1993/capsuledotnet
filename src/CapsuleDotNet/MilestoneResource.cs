using System;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;

namespace CapsuleDotNet
{
    public static class MilestoneResource
    {
        private const string BASE_ENDPOINT = "milestones";
        
        public static MilestoneWrapper List(DateTime? since = null, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            return MilestoneResource.ListAsync(since, page, perPage, embed).Result;
        }

        public async static Task<MilestoneWrapper> ListAsync(DateTime? since = null, int page = 1, int perPage = 20, Embed[] embed = null)
        {
            var opportunities = await CapsuleClient.baseGetRequest<MilestoneWrapper>(BASE_ENDPOINT, since, page, perPage, embed);

            return opportunities;
        }

    }
}