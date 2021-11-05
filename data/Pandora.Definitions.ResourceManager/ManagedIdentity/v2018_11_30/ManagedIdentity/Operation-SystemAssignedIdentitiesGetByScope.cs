using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
    internal class SystemAssignedIdentitiesGetByScopeOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ScopeId();

        public override Type? ResponseObject() => typeof(SystemAssignedIdentityModel);

        public override string? UriSuffix() => "/providers/Microsoft.ManagedIdentity/identities/default";


    }
}
