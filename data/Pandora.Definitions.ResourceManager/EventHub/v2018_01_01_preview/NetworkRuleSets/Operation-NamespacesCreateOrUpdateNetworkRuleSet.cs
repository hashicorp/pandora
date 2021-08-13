using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NetworkRuleSets
{
    internal class NamespacesCreateOrUpdateNetworkRuleSetOperation : Operations.PutOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(NetworkRuleSetModel);
        }

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
