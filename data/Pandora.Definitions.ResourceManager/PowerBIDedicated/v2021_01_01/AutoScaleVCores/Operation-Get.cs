using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new AutoScaleVCoreId();

        public override Type? ResponseObject() => typeof(AutoScaleVCoreModel);


    }
}
