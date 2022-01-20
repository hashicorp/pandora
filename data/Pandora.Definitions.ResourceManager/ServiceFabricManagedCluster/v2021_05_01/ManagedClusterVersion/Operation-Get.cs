using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedClusterVersion;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ManagedClusterVersionId();

    public override Type? ResponseObject() => typeof(ManagedClusterCodeVersionResultModel);


}
