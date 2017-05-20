﻿using NDomain.Bus.Subscriptions;
using NDomain.Tests.Specs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDomain.Tests.Bus.Subscriptions
{
    [TestFixture]
    public class LocalSubscriptionBrokerTests : SubscriptionBrokerSpecs
    {
        protected override ISubscriptionBroker CreateSubscriptionBroker()
        {
            return new LocalSubscriptionBroker();
        }
    }
}
