using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.EventHubs
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new EventhubId();
        }

        public override Type? ResponseObject()
        {
            return typeof(EventhubModel);
        }


    }
}
