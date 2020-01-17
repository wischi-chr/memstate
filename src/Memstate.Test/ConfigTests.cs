using System;
using Memstate.Configuration;
using NUnit.Framework;

namespace Memstate.Test
{
    [TestFixture]
    public class ConfigTests
    {
        [Test]
        public void CanGetDefaultSerializer()
        {
            var config = new Config();
            var serializer = config.CreateSerializer();
            Assert.NotNull(serializer);
        }

        [Test]
        public void EnvironmentVariableWithUnderscoresAndMatchingCase()
        {
            var key = "Memstate:Postgres:Password";
            var varName = "Memstate_Postgres_Password";
            var value = Guid.NewGuid().ToString();
            Environment.SetEnvironmentVariable(varName, value);
            var config = Config.Reset();
            Assert.True(config.Data.ContainsKey(key));
        }

        [Test]
        public void EnvironmentVariableWithUnderscoresAndUpperCase()
        {
            var key = "Memstate:Postgres:Password";
            var varName = "MEMSTATE_POSTGRES_PASSWORD";
            var value = Guid.NewGuid().ToString();
            Environment.SetEnvironmentVariable(varName, value);
            var config = Config.Reset();
            Assert.True(config.Data.ContainsKey(key));
        }

        [Test]
        public void EnvironmentVariableWithColonSeparator()
        {
            var key = "Memstate:Postgres:Password";
            var varName = "MEMSTATE:POSTGRES:PASSWORD";
            var value = Guid.NewGuid().ToString();
            Environment.SetEnvironmentVariable(varName, value);
            var config = Config.Reset();
            Assert.True(config.Data.ContainsKey(key));
        }
    }
}