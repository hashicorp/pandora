using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.CheckNameAvailabilityDisasterRecoveryConfigs
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

        public override object? RequestObject()
        {
            return new CheckNameAvailabilityParameterModel();
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override object? ResponseObject()
        {
            return new CheckNameAvailabilityResultModel();
        }

        public override string? UriSuffix()
        {
            return "/disasterRecoveryConfigs/checkNameAvailability";
        }


    }
}
