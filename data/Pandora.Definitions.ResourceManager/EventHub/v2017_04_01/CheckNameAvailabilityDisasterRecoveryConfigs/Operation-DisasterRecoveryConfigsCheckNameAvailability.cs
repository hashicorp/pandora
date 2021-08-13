using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.CheckNameAvailabilityDisasterRecoveryConfigs
{
    internal class DisasterRecoveryConfigsCheckNameAvailabilityOperation : Operations.PostOperation
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
            return typeof(CheckNameAvailabilityParameterModel);
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override Type? ResponseObject()
        {
            return typeof(CheckNameAvailabilityResultModel);
        }

        public override string? UriSuffix()
        {
            return "/disasterRecoveryConfigs/checkNameAvailability";
        }


    }
}
