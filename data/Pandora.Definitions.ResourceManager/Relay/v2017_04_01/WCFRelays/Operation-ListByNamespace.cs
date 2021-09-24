using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.WCFRelays
{
    internal class ListByNamespaceOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new NamespaceId();

        public override Type NestedItemType() => typeof(WcfRelayModel);

        public override string? UriSuffix() => "/wcfRelays";


    }
}
