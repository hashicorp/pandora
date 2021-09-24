using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Clusters
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(ClusterModel);

        public override ResourceID? ResourceId() => new ClusterId();

        public override Type? ResponseObject() => typeof(ClusterModel);


    }
}
