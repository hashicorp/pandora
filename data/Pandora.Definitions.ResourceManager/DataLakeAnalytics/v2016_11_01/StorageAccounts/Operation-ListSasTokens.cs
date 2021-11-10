using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.StorageAccounts
{
    internal class ListSasTokensOperation : Operations.ListOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override Type? RequestObject() => null;

        public override ResourceID? ResourceId() => new ContainerId();

        public override Type NestedItemType() => typeof(SasTokenInformationModel);

        public override string? UriSuffix() => "/listSasTokens";

        public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


    }
}
