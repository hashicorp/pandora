using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.PrivateLinkResources
{
    internal class ListByClusterOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new RedisEnterpriseId();

        public override Type? ResponseObject() => typeof(PrivateLinkResourceListResultModel);

        public override string? UriSuffix() => "/privateLinkResources";


    }
}
