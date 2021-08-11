using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.CheckNameAvailabilityNamespaces
{
    internal class NamespacesCheckNameAvailabilityOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override object? RequestObject()
        {
            return new CheckNameAvailabilityParameterModel();
        }

        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override object? ResponseObject()
        {
            return new CheckNameAvailabilityResultModel();
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.EventHub/checkNameAvailability";
        }


    }
}
