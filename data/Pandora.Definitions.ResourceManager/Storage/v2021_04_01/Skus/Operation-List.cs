using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.Skus;

internal class ListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(StorageSkuListResultModel);

    public override string? UriSuffix() => "/providers/Microsoft.Storage/skus";


}
