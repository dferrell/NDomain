﻿using NDomain.Bus.Transport;
using NUnit.Framework;
using StackExchange.Redis;
using System;
using NDomain.Redis.Bus.Transport;
using NDomain.Tests.Common.Specs;

namespace NDomain.Redis.Tests.Bus.Transport
{
    [TestFixture(Category = "Redis")]
    public class RedisTransportTests : TransportSpecs
    {
        private static readonly string ServerEndpoint = "localhost:6379";

        private ConnectionMultiplexer connection;

        [OneTimeSetUp]
        public void SetUpFixture()
        {
            var options = new ConfigurationOptions();
            options.AllowAdmin = true;
            options.EndPoints.Add(ServerEndpoint);

            try
            {
                this.connection = ConnectionMultiplexer.Connect(options);
                this.connection.PreserveAsyncOrder = false;
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(ex.Message);
            }
        }

        public override ITransportFactory CreateFactory()
        {
            return new RedisTransportFactory(connection, "ndomain.redis.tests");
        }

        protected override void OnSetUp()
        {
            Clear();
        }

        protected override void OnTearDown()
        {
            Clear();
        }

        private void Clear()
        {
            var keys = connection.GetServer(ServerEndpoint)
                                 .Keys(pattern: "ndomain.redis.tests*");

            var redis = connection.GetDatabase();
            foreach (var key in keys)
            {
                redis.KeyDelete(key);
            }
        }
    }
}
