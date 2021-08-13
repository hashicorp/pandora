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
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(CheckServerNameAvailabilityParametersModel);
        }

        public override ResourceID? ResourceId()
        {
            return new LocationId();
        }

        public override Type? ResponseObject()
        {
            return typeof(CheckServerNameAvailabilityResultModel);
        }

        public override string? UriSuffix()
        {
            return "/checkNameAvailability";
        }


    }
}
