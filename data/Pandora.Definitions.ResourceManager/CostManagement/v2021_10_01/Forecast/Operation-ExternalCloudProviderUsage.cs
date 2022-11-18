using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Forecast;

internal class ExternalCloudProviderUsageOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ForecastDefinitionModel);

\t\tpublic override ResourceID? ResourceId() => new ExternalCloudProviderTypeId();

\t\tpublic override Type? ResponseObject() => typeof(ForecastResultModel);

\t\tpublic override Type? OptionsObject() => typeof(ExternalCloudProviderUsageOperation.ExternalCloudProviderUsageOptions);

\t\tpublic override string? UriSuffix() => "/forecast";

    internal class ExternalCloudProviderUsageOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
