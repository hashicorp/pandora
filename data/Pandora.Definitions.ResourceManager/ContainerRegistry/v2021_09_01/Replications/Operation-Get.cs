using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Replications;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ReplicationId();

    public override Type? ResponseObject() => typeof(ReplicationModel);


}
