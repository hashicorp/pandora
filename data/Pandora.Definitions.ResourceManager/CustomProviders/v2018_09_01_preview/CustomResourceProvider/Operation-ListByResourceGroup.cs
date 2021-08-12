using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.CustomResourceProvider
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

        public override object NestedItemType()
        {
            return new CustomRPManifestModel();
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.CustomProviders/resourceProviders";
        }


    }
}
