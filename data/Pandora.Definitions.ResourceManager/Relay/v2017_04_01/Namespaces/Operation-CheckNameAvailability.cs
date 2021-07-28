using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces
{
    internal class CheckNameAvailabilityOperation : Operations.PostOperation
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
            return new CheckNameAvailability();
        }

        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override object? ResponseObject()
        {
            return new CheckNameAvailabilityResult();
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.Relay/checkNameAvailability";
        }


    }
}
