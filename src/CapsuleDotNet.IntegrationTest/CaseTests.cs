using System;
using System.Linq;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CapsuleDotNet.IntegrationTest
{
    public class CaseTests
    {
        public CaseTests()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<CaseTests>();

            var _configuration = builder.Build();

            CapsuleClient.Init(_configuration["CapsuleApiKey"]);
        }

        [Fact]
        public void GET_CASES_NO_PARAMS()
        {
            // Arrange

            // Act
            var cases = CaseResource.List();

            // Assert
            Assert.True(cases.Cases.AsQueryable().Count() > 0);
        }

        [Fact]
        public void GET_SPECIFIC_CASE()
        {
            // Arrange
            var caseId = 2675768;
            var embed = new Embed[1];
            embed[0] = Embed.Tags;

            // Act
            var caseObject = CaseResource.Show(caseId, embed);

            // Assert
            Assert.Equal("Dev Case", caseObject.Name);
        }

        [Fact]
        public void GET_SPECIFIC_CASE_ADDITIONAL_PARTIES()
        {
            // Arrange
            var caseId = 2675768;
            var embed = new Embed[1];
            embed[0] = Embed.Tags;

            // Act
            var parties = CaseResource.ListAdditionalParties(caseId, 1, 20, embed);

            // Assert
            Assert.True(parties.Parties.AsQueryable().Count() > 0);
        }

        [Fact]
        public void SEARCH_CASE()
        {
            // Arrange;
            var queryText = "Dev";

            // Act
            var caseObject = CaseResource.SearchCases(queryText);

            // Assert
            Assert.True(caseObject.Cases.AsQueryable().Count() > 0);
        }

        [Fact]
        public void GET_MULTIPLE_CASES()
        {
            // Arrange
            var caseIds = new string[2];
            caseIds[0] = "2675768";
            caseIds[1] = "2675769";
            var embed = new Embed[1];
            embed[0] = Embed.Tags;

            // Act
            var caseObject = CaseResource.ShowMultipleAsync(caseIds, embed).Result;

            // Assert
            Assert.Equal(2, caseObject.Cases.AsQueryable().Count());
        }

        [Fact]
        public void CREATE_CASE()
        {
            // Arrange
            var partyId = 187341289;
            var embed = new Embed[1];
            embed[0] = Embed.Tags;

            var party = PartyResource.Show(partyId, embed);
            var caseObject = Case.Create(nestedParty: party
                ,name: $"Integration test {DateTime.Now.ToString("yyyyMMddHHmmss")}");

            // Act
            var createdCase = CaseResource.CreateAsync(caseObject).Result;

            // Assert
            Assert.True(createdCase.Id > 0);
        }
    
        [Fact]
        public void UPDATE_CASE(){
            // Arrange
            var newDescription = Guid.NewGuid().ToString();
            var caseId = 2675769;
            var embed = new Embed[1];
            embed[0] = Embed.Tags;
            var caseObject = CaseResource.Show(caseId, embed);
            caseObject.Description = newDescription;

            // Act
            var updateResponse = CaseResource.Update(caseId, caseObject);

            // Assert
            Assert.Equal(newDescription, updateResponse.Description);
        }
    
        [Fact]
        public void DELETE_CASE(){
            // Arrange
            var partyId = 187341289;
            var embed = new Embed[1];
            embed[0] = Embed.Tags;

            var party = PartyResource.Show(partyId, embed);
            var caseObject = Case.Create(nestedParty: party
                ,name: $"Delete test {DateTime.Now.ToString("yyyyMMddHHmmss")}");

            var createdCase = CaseResource.CreateAsync(caseObject).Result;

            // Act
            var deleteResponse = CaseResource.Delete(createdCase.Id.Value);

            Assert.True(deleteResponse);
        }
    }
}