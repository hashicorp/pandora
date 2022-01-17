using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Targets
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new TargetId();

        public override Type? ResponseObject() => typeof(TargetModel);


    }
}
