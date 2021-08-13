using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Namespaces
{
    internal class ListByResourceGroupOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new ResourceGroupId();
        }

        public override Type NestedItemType()
        {
            return typeof(EHNamespaceModel);
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.EventHub/namespaces";
        }


    }
}
