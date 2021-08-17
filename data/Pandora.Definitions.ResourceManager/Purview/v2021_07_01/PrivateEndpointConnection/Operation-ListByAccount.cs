using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.PrivateEndpointConnection
{
    internal class ListByAccountOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new AccountId();
        }

        public override Type NestedItemType()
        {
            return typeof(PrivateEndpointConnectionModel);
        }

        public override string? UriSuffix()
        {
            return "/privateEndpointConnections";
        }


    }
}
