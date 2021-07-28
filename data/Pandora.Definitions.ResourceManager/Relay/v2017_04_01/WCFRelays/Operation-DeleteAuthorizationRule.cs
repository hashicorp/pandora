using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.WCFRelays
{
    internal class DeleteAuthorizationRuleOperation : Operations.DeleteOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
            };
        }

        public override ResourceID? ResourceId()
        {
            return new AuthorizationRuleId();
        }


    }
}
