using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class RegenerateKeyOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(RegenerateKeyParametersModel);

        public override ResourceID? ResourceId() => new ConfigurationStoreId();

        public override Type? ResponseObject() => typeof(ApiKeyModel);

        public override string? UriSuffix() => "/regenerateKey";


    }
}
