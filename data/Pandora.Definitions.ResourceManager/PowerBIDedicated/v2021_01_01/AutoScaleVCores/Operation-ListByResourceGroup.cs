using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores
{
    internal class ListByResourceGroupOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ResourceGroupProviderId();

        public override Type? ResponseObject() => typeof(AutoScaleVCoreListResultModel);

        public override string? UriSuffix() => "/autoScaleVCores";


    }
}
