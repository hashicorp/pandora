using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces
{
    internal class CheckNameAvailabilityOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(CheckNameAvailabilityModel);

        public override ResourceID? ResourceId() => new SubscriptionId();

        public override Type? ResponseObject() => typeof(CheckNameAvailabilityResultModel);

        public override string? UriSuffix() => "/providers/Microsoft.Relay/checkNameAvailability";


    }
}
