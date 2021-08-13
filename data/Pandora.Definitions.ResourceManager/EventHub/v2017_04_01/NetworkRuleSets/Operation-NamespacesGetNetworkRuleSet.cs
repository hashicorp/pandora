using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.NetworkRuleSets
{
    internal class NamespacesGetNetworkRuleSetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override Type? ResponseObject()
        {
            return typeof(NetworkRuleSetModel);
        }

        public override string? UriSuffix()
        {
            return "/networkRuleSets/default";
        }


    }
}
