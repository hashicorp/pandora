using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views;

internal class ListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type NestedItemType() => typeof(ViewModel);

    public override string? UriSuffix() => "/providers/Microsoft.CostManagement/views";


}
