using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.HybridConnections
{
    internal class CreateOrUpdateAuthorizationRuleOperation : Operations.PutOperation
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
            return new AuthorizationRuleModel();
        }

        public override ResourceID? ResourceId()
        {
            return new AuthorizationRuleId();
        }

        public override object? ResponseObject()
        {
            return new AuthorizationRuleModel();
        }


    }
}
