using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
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
            return new CheckCapacityNameAvailabilityParametersModel();
        }

        public override ResourceID? ResourceId()
        {
            return new LocationId();
        }

        public override object? ResponseObject()
        {
            return new CheckCapacityNameAvailabilityResultModel();
        }

        public override string? UriSuffix()
        {
            return "/checkNameAvailability";
        }


    }
}
