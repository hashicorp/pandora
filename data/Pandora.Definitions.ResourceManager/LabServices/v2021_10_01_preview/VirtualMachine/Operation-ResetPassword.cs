using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.VirtualMachine
{
    internal class ResetPasswordOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(ResetPasswordBodyModel);

        public override ResourceID? ResourceId() => new VirtualMachineId();

        public override string? UriSuffix() => "/resetPassword";


    }
}
