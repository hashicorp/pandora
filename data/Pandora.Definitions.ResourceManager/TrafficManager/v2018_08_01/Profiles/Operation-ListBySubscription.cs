using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles;

internal class ListBySubscriptionOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(ProfileListResultModel);

    public override string? UriSuffix() => "/providers/Microsoft.Network/trafficManagerProfiles";


}
