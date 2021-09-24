using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesEventHubs
{
    internal class EventHubsRegenerateKeysOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(RegenerateAccessKeyParametersModel);

        public override ResourceID? ResourceId() => new AuthorizationRuleId();

        public override Type? ResponseObject() => typeof(AccessKeysModel);

        public override string? UriSuffix() => "/regenerateKeys";


    }
}
