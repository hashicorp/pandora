using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.MessagingPlan
{
    internal class NamespacesGetMessagingPlanOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new NamespaceId();

        public override Type? ResponseObject() => typeof(MessagingPlanModel);

        public override string? UriSuffix() => "/messagingplan";


    }
}
