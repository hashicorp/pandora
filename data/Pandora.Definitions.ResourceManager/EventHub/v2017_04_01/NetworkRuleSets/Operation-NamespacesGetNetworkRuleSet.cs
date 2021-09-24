using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.NetworkRuleSets
{
    internal class NamespacesGetNetworkRuleSetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new NamespaceId();

        public override Type? ResponseObject() => typeof(NetworkRuleSetModel);

        public override string? UriSuffix() => "/networkRuleSets/default";


    }
}
