using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class RegenerateKeyOperation : Operations.PostOperation
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
            return new RegenerateKeyParametersModel();
        }

        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }

        public override object? ResponseObject()
        {
            return new ApiKeyModel();
        }

        public override string? UriSuffix()
        {
            return "/RegenerateKey";
        }


    }
}
