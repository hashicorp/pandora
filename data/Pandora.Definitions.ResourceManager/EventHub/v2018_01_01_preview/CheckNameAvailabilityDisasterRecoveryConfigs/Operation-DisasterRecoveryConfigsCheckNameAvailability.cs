using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.CheckNameAvailabilityDisasterRecoveryConfigs
{
    internal class DisasterRecoveryConfigsCheckNameAvailability : PostOperation
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
            return new CheckNameAvailabilityParameter();
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override object? ResponseObject()
        {
            return new CheckNameAvailabilityResult();
        }

        public override string? UriSuffix()
        {
            return "/disasterRecoveryConfigs/checkNameAvailability";
        }
    }
}
