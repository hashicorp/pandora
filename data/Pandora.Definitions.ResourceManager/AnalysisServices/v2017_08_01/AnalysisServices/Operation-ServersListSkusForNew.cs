using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.AnalysisServices
{
    internal class ServersListSkusForNewOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override object? ResponseObject()
        {
            return new SkuEnumerationForNewResourceResult();
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.AnalysisServices/skus";
        }


    }
}
