using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Capabilities
{
    internal class CapabilityTypesGetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new CapabilityTypeId();

        public override Type? ResponseObject() => typeof(CapabilityTypeModel);


    }
}
