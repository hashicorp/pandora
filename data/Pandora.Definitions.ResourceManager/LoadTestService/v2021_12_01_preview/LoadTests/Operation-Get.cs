using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.LoadTestService.v2021_12_01_preview.LoadTests
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new LoadTestId();

        public override Type? ResponseObject() => typeof(LoadTestResourceModel);


    }
}
