using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.WCFRelays
{
    internal class ListAuthorizationRulesOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new WcfRelayId();
        }

        public override object NestedItemType()
        {
            return new AuthorizationRule();
        }

        public override string? UriSuffix()
        {
            return "/authorizationRules";
        }


    }
}
