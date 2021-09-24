using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.HcxEnterpriseSites
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override Type? RequestObject() => typeof(HcxEnterpriseSiteModel);

        public override ResourceID? ResourceId() => new HcxEnterpriseSiteId();

        public override Type? ResponseObject() => typeof(HcxEnterpriseSiteModel);


    }
}
