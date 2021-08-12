using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.Associations
{
    internal class ListAllOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override object NestedItemType()
        {
            return new AssociationModel();
        }

        public override string? UriSuffix()
        {
            return "/{scope}/providers/Microsoft.CustomProviders/associations";
        }


    }
}
