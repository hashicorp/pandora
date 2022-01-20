using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.PowerBIDedicated;

internal class CapacitiesListSkusOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(SkuEnumerationForNewResourceResultModel);

    public override string? UriSuffix() => "/providers/Microsoft.PowerBIDedicated/skus";


}
