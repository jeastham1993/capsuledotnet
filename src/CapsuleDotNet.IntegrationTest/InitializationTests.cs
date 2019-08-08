using System;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CapsuleDotNet.UnitTest
{
    public class InitializationTests
    {
        private readonly IConfiguration _configuration;

        public InitializationTests(){
            // the type specified here is just so the secrets library can 
            // find the UserSecretId we added in the csproj file
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<InitializationTests>();

            _configuration = builder.Build();
        }
        [Fact]
        public void INIT_VALID_API_KEY()
        {
            var result = CapsuleClient.Init(_configuration["CapsuleApiKey"]);

            Assert.True(result);
        }

        [Fact]
        public void INIT_INVALID_API_KEY()
        {
            Assert.Throws<ArgumentException>(() => {
                CapsuleClient.Init("blah blah blah");
            });
        }
    }
}
