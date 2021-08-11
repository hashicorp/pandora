using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.WCFRelays
{
    internal class RegenerateKeysOperation : Operations.PostOperation
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
            return new RegenerateAccessKeyParametersModel();
        }

        public override ResourceID? ResourceId()
        {
            return new AuthorizationRuleId();
        }

        public override object? ResponseObject()
        {
            return new AccessKeysModel();
        }

        public override string? UriSuffix()
        {
            return "/regenerateKeys";
        }


    }
}
