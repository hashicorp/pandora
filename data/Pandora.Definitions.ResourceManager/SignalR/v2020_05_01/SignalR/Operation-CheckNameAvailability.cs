using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
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

        public override Type? RequestObject()
        {
            return typeof(NameAvailabilityParametersModel);
        }

        public override ResourceID? ResourceId()
        {
            return new LocationId();
        }

        public override Type? ResponseObject()
        {
            return typeof(NameAvailabilityModel);
        }

        public override string? UriSuffix()
        {
            return "/checkNameAvailability";
        }


    }
}
