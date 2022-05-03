using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.ConsumerGroups;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ConsumerGroupId();

    public override Type? ResponseObject() => typeof(ConsumerGroupModel);


}
