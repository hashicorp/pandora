using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{
    internal class CheckDomainAvailabilityOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(CheckDomainAvailabilityParameterModel);

        public override ResourceID? ResourceId() => new SubscriptionId();

        public override Type? ResponseObject() => typeof(DomainAvailabilityModel);

        public override string? UriSuffix() => "/providers/Microsoft.CognitiveServices/checkDomainAvailability";


    }
}
