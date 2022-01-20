using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Query;

internal class UsageByExternalCloudProviderTypeOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(QueryDefinitionModel);

    public override ResourceID? ResourceId() => new ExternalCloudProviderTypeId();

    public override Type? ResponseObject() => typeof(QueryResultModel);

    public override string? UriSuffix() => "/query";


}
