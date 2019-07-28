using System;
using System.Collections.Generic;
using System.Linq;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CapsuleDotNet.IntegrationTest
{
    public class OpportunityTests
    {
        public OpportunityTests()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<PartyTests>();

            var _configuration = builder.Build();

            CapsuleClient.Init(_configuration["CapsuleApiKey"]);
        }

        [Fact]
        public void GET_OPPORTUNITIES_NO_PARAMS()
        {
            // Arrange

            // Act
            var opps = OpportunityResource.List();

            // Assert
            Assert.True(opps.Opportunities.AsQueryable().Count() > 0);
        }
    
        [Fact]
        public void LIST_BY_PARTY(){
            // Arrange
            long partyId = 187341289;

            // Act
            var opps = OpportunityResource.ListByParty(partyId);

            // Assert
            Assert.True(opps.Opportunities.AsQueryable().Count() > 0);
        }

        [Fact]
        public void SHOW(){
            long opportunityId = 8253984;

            var opportunity = OpportunityResource.Show(opportunityId);

            Assert.Equal("Capsule Dot Net", opportunity.Name);
        }
    
        [Fact]
        public void SHOW_MULTIPLE(){ 
            long[] ids = new long[2];
            ids[0] = 8253984;
            ids[1] = 8259267;

            var opps = OpportunityResource.ShowMultiple(ids, new List<Embed>(){Embed.Tags}.ToArray());

            Assert.True(opps.Opportunities.AsQueryable().Count() == 2);
            Assert.True(opps.Opportunities.FirstOrDefault().Tags.Count > 0);
        }
    
        [Fact]
        public void CREATE() {
            // Arrange
            var getParty = PartyResource.Show(187341289);
            var milestone = MilestoneResource.List();

            var opp = Opportunity.Create(nestedParty: getParty, 
                name: $"Integration Test - {DateTime.Now.ToString("yyyyMMddHHmmss")}",
                nestedMilestone: milestone.Milestones.FirstOrDefault());
            
            // Act 
            var createResponse = OpportunityResource.Create(opp);

            // Assert
            Assert.True(createResponse.Id > 0);
        }
    
        [Fact]
        public void UPDATE() {
            // Arrange
            long opportunityId = 8253984;
            var updatedDesc = Guid.NewGuid().ToString();

            var opportunity = OpportunityResource.Show(opportunityId);
            opportunity.Description = updatedDesc;
            
            // Act 
            var updateResponse = OpportunityResource.Update(opportunityId, opportunity);

            // Assert
            Assert.Equal(updatedDesc, updateResponse.Description);
        }
    
    }
}