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
            var parties = PartyResource.GetAsync().Result;

            // Assert
            Assert.True(parties.Parties.Count > 0);
        }

        [Fact]
        public void GET_SPECIFIC_PARTY()
        {
            // Arrange
            var partyId = "187341289";
            var embed = new EmbedEnum[1];
            embed[0] = EmbedEnum.Tags;

            // Act
            var party = PartyResource.GetSpecificAsync(partyId, embed).Result;

            // Assert
            Assert.Equal("John", party.FirstName);
            Assert.True(party.Addresses.Count > 0);
            Assert.True(party.Websites.Count > 0);
            Assert.True(party.PhoneNumbers.Count > 0);
            Assert.True(party.Tags.Count > 0);
            Assert.True(party.EmailAddresses.Count > 0);
        }
    }
}