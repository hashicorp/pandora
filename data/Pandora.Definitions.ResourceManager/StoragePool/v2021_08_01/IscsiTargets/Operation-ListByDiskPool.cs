using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.IscsiTargets;

internal class ListByDiskPoolOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new DiskPoolId();

    public override Type NestedItemType() => typeof(IscsiTargetModel);

    public override string? UriSuffix() => "/iscsiTargets";


}
