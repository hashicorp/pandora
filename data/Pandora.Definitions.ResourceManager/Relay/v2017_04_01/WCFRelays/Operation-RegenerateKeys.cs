using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
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

        public override Type? RequestObject()
        {
            return typeof(RegenerateAccessKeyParametersModel);
        }

        public override ResourceID? ResourceId()
        {
            return new AuthorizationRuleId();
        }

        public override Type? ResponseObject()
        {
            return typeof(AccessKeysModel);
        }

        public override string? UriSuffix()
        {
            return "/regenerateKeys";
        }


    }
}
