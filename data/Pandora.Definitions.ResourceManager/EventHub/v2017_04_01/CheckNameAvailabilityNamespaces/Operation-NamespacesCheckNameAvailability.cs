using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.CheckNameAvailabilityNamespaces
{
    internal class NamespacesCheckNameAvailabilityOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(CheckNameAvailabilityParameterModel);

        public override ResourceID? ResourceId() => new ProviderId();

        public override Type? ResponseObject() => typeof(CheckNameAvailabilityResultModel);

        public override string? UriSuffix() => "/checkNameAvailability";


    }
}
