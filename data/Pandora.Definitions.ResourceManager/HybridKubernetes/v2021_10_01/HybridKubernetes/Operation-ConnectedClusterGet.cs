using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.HybridKubernetes;

internal class ConnectedClusterGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ConnectedClusterId();

    public override Type? ResponseObject() => typeof(ConnectedClusterModel);


}
