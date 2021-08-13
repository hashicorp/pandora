using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores
{
    internal class UpdateOperation : Operations.PatchOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(AutoScaleVCoreUpdateParametersModel);
        }

        public override ResourceID? ResourceId()
        {
            return new AutoScaleVCoreId();
        }

        public override Type? ResponseObject()
        {
            return typeof(AutoScaleVCoreModel);
        }


    }
}
