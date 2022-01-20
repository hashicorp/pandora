using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateLinkResources;

internal class ListByConfigurationStoreOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ConfigurationStoreId();

    public override Type NestedItemType() => typeof(PrivateLinkResourceModel);

    public override string? UriSuffix() => "/privateLinkResources";


}
