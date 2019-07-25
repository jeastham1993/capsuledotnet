using System;
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
    }
}