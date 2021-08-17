using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.PrivateLinkResource
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
            return typeof(PrivateLinkResourceModel);
        }

        public override string? UriSuffix()
        {
            return "/privateLinkResources";
        }


    }
}
