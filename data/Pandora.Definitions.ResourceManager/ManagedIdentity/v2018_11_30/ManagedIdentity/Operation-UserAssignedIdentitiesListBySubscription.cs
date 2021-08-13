using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
    internal class UserAssignedIdentitiesListBySubscriptionOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override Type NestedItemType()
        {
            return typeof(IdentityModel);
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.ManagedIdentity/userAssignedIdentities";
        }


    }
}
