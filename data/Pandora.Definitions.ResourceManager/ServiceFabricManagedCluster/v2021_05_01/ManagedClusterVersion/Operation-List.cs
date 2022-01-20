using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedClusterVersion;

internal class ListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(List<ManagedClusterCodeVersionResultModel>);

    public override string? UriSuffix() => "/managedClusterVersions";


}
