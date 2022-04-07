using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Operation;

internal class RegistriesCheckNameAvailabilityOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(RegistryNameCheckRequestModel);

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(RegistryNameStatusModel);

    public override string? UriSuffix() => "/providers/Microsoft.ContainerRegistry/checkNameAvailability";


}
