using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;

internal class SharedPrivateLinkResourcesCreateOrUpdateOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(SharedPrivateLinkResourceModel);

    public override ResourceID? ResourceId() => new SharedPrivateLinkResourceId();

    public override Type? ResponseObject() => typeof(SharedPrivateLinkResourceModel);


}
