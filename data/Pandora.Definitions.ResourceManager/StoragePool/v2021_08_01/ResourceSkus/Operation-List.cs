using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.ResourceSkus
{
    internal class ListOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new LocationId();

        public override Type NestedItemType() => typeof(ResourceSkuInfoModel);

        public override string? UriSuffix() => "/skus";


    }
}
