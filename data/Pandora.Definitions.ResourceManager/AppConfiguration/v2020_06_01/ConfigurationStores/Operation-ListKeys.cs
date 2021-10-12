using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class ListKeysOperation : Operations.ListOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override Type? RequestObject() => null;

        public override ResourceID? ResourceId() => new ConfigurationStoreId();

        public override Type NestedItemType() => typeof(ApiKeyModel);

        public override string? UriSuffix() => "/listKeys";

        public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


    }
}
