using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.TrustedIdProviders;

internal class ListByAccountOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new AccountId();

    public override Type NestedItemType() => typeof(TrustedIdProviderModel);

    public override string? UriSuffix() => "/trustedIdProviders";


}
