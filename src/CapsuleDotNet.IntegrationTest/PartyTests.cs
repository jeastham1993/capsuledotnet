using System;
using System.Linq;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CapsuleDotNet.IntegrationTest
{
    public class PartyTests
    {
        public PartyTests()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<PartyTests>();

            var _configuration = builder.Build();

            CapsuleClient.Init(_configuration["CapsuleApiKey"]);
        }

        [Fact]
        public void GET_PARTIES_NO_PARAMS()
        {
            // Arrange

            // Act
            var parties = PartyResource.List();

            // Assert
            Assert.True(parties.Parties.AsQueryable().Count() > 0);
        }

        [Fact]
        public void GET_SPECIFIC_PARTY()
        {
            // Arrange
            var partyId = "187341289";
            var embed = new Embed[1];
            embed[0] = Embed.Tags;

            // Act
            var party = PartyResource.Show(partyId, embed);

            // Assert
            Assert.Equal("John", party.FirstName);
            Assert.True(party.Addresses.Count > 0);
            Assert.True(party.Websites.Count > 0);
            Assert.True(party.PhoneNumbers.Count > 0);
            Assert.True(party.Tags.Count > 0);
            Assert.True(party.EmailAddresses.Count > 0);
        }

        [Fact]
        public void SEARCH_PARTY()
        {
            // Arrange;
            var queryText = "John";

            // Act
            var party = PartyResource.SearchParties(queryText);

            // Assert
            Assert.Equal("John", party.Parties.FirstOrDefault().FirstName);
            Assert.Equal("Doe", party.Parties.FirstOrDefault().LastName);
        }

        [Fact]
        public void GET_MULTIPLE_PARTIES()
        {
            // Arrange
            var partyIds = new string[2];
            partyIds[0] = "187341517";
            partyIds[1] = "187341289";
            var embed = new Embed[1];
            embed[0] = Embed.Tags;

            // Act
            var party = PartyResource.ShowMultipleAsync(partyIds, embed).Result;

            // Assert
            Assert.Equal(2, party.Parties.AsQueryable().Count());
        }

        [Fact]
        public void CREATE_PARTY()
        {
            // Arrange
            var party = Party.Create(PartyType.PERSON);
            party.FirstName = "Integration test";
            party.LastName = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            party.Title = "Mr";
            party.JobTitle = "Software Engineer";
            party.About = "I am a software engineer";
            party.AddAddress(AddressType.Home, "My street", "My city", "My state", "United Kingdom", "123456");
            party.AddEmailAddress(EmailAddressType.Home, "capsuledotnet@dotnet.com");
            party.AddPhoneNumber(PhoneNumberType.Home, "123456");
            party.AddWebsite(WebsiteType.Home, WebsiteService.GITHUB, "jeastham1993", "https://github.com/jeastham1993");
            party.AddTag("My tag", "A description of my tag");

            // Act
            var createdParty = PartyResource.CreateAsync(party).Result;

            // Assert
            Assert.True(createdParty.Id > 0);
            Assert.True(createdParty.Addresses.Count == 1);
            Assert.True(createdParty.EmailAddresses.Count == 1);
            Assert.True(createdParty.Websites.Count == 1);
            Assert.True(createdParty.PhoneNumbers.Count == 1);
        }
    
        [Fact]
        public void UPDATE_PARTY(){
            // Arrange
            var partyId = "187341289";
            var embed = new Embed[1];
            embed[0] = Embed.Tags;
            var party = PartyResource.Show(partyId, embed);

            var newAbout = DateTime.Now.ToString("yyyyMMddHHmmss");

            party.About = newAbout;

            // Act
            var updateResponse = PartyResource.Update(long.Parse(partyId), party);

            // Assert
            Assert.Equal(newAbout, updateResponse.About);
        }
    
        [Fact]
        public void DELETE_PARTY(){
            // Arrange
            var party = Party.Create(PartyType.PERSON);
            party.FirstName = "Integration test";
            party.LastName = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            party.Title = "Mr";
            party.JobTitle = "Software Engineer";
            party.About = "I am a software engineer";
            party.AddAddress(AddressType.Home, "My street", "My city", "My state", "United Kingdom", "123456");
            party.AddEmailAddress(EmailAddressType.Home, "capsuledotnet@dotnet.com");
            party.AddPhoneNumber(PhoneNumberType.Home, "123456");
            party.AddWebsite(WebsiteType.Home, WebsiteService.GITHUB, "jeastham1993", "https://github.com/jeastham1993");
            party.AddTag("My tag", "A description of my tag");

            var createdParty = PartyResource.CreateAsync(party).Result;

            // Act
            var deleteResponse = PartyResource.Delete(createdParty.Id.Value);

            Assert.True(deleteResponse);
            
        }
    }
}