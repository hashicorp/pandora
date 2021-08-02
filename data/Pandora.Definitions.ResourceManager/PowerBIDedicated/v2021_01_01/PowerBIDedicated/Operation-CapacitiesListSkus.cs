using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.PowerBIDedicated
{
    internal class CapacitiesListSkusOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override object? ResponseObject()
        {
            return new SkuEnumerationForNewResourceResultModel();
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.PowerBIDedicated/skus";
        }


    }
}
