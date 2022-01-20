using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ApplicationTypeVersion;

internal class ListByApplicationTypesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ApplicationTypeId();

    public override Type NestedItemType() => typeof(ApplicationTypeVersionResourceModel);

    public override string? UriSuffix() => "/versions";


}
