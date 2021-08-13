using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class ListKeysOperation : Operations.ListOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override Type? RequestObject()
        {
            return null;
        }

        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }

        public override Type NestedItemType()
        {
            return typeof(ApiKeyModel);
        }

        public override string? UriSuffix()
        {
            return "/ListKeys";
        }

        public override System.Net.Http.HttpMethod Method()
        {
            return System.Net.Http.HttpMethod.Post;
        }


    }
}
