using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores
{
    internal class ListBySubscriptionOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override Type? ResponseObject()
        {
            return typeof(AutoScaleVCoreListResultModel);
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.PowerBIDedicated/autoScaleVCores";
        }


    }
}
