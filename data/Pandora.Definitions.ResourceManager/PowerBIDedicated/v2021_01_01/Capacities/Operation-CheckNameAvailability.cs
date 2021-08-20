using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{
    internal class CheckNameAvailabilityOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(CheckCapacityNameAvailabilityParametersModel);

        public override ResourceID? ResourceId() => new LocationId();

        public override Type? ResponseObject() => typeof(CheckCapacityNameAvailabilityResultModel);

        public override string? UriSuffix() => "/checkNameAvailability";


    }
}
