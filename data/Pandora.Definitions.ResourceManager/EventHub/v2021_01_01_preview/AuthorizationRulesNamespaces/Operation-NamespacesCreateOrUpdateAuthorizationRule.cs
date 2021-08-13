using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesNamespaces
{
    internal class NamespacesCreateOrUpdateAuthorizationRuleOperation : Operations.PutOperation
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
            return typeof(AuthorizationRuleModel);
        }

        public override ResourceID? ResourceId()
        {
            return new AuthorizationRuleId();
        }

        public override Type? ResponseObject()
        {
            return typeof(AuthorizationRuleModel);
        }


    }
}
