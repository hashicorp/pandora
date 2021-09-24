using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(PrivateCloudModel);

        public override ResourceID? ResourceId() => new PrivateCloudId();

        public override Type? ResponseObject() => typeof(PrivateCloudModel);


    }
}
