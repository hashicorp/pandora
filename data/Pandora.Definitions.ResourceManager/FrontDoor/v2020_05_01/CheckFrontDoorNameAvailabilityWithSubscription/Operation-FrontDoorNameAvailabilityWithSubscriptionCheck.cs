using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.CheckFrontDoorNameAvailabilityWithSubscription;

internal class FrontDoorNameAvailabilityWithSubscriptionCheckOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CheckNameAvailabilityInputModel);

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(CheckNameAvailabilityOutputModel);

    public override string? UriSuffix() => "/providers/Microsoft.Network/checkFrontDoorNameAvailability";


}
