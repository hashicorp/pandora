using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class CheckNameAvailabilityOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(CheckServerNameAvailabilityParametersModel);

        public override ResourceID? ResourceId() => new LocationId();

        public override Type? ResponseObject() => typeof(CheckServerNameAvailabilityResultModel);

        public override string? UriSuffix() => "/checkNameAvailability";


    }
}
