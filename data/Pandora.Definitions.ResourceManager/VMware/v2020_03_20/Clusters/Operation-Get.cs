using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Clusters
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ClusterId();

        public override Type? ResponseObject() => typeof(ClusterModel);


    }
}
