using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Forecast;

internal class ExternalCloudProviderUsageOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ForecastDefinitionModel);

    public override ResourceID? ResourceId() => new ExternalCloudProviderTypeId();

    public override Type? ResponseObject() => typeof(QueryResultModel);

    public override Type? OptionsObject() => typeof(ExternalCloudProviderUsageOperation.ExternalCloudProviderUsageOptions);

    public override string? UriSuffix() => "/forecast";

    internal class ExternalCloudProviderUsageOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
