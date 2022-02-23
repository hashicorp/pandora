using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

internal class CheckNameAvailabilityOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(StorageAccountCheckNameAvailabilityParametersModel);

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(CheckNameAvailabilityResultModel);

    public override string? UriSuffix() => "/providers/Microsoft.Storage/checkNameAvailability";


}
