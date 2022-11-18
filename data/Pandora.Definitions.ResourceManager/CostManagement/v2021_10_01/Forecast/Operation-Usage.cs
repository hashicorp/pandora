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

internal class UsageOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ForecastDefinitionModel);

\t\tpublic override ResourceID? ResourceId() => new ScopeId();

\t\tpublic override Type? ResponseObject() => typeof(ForecastResultModel);

\t\tpublic override Type? OptionsObject() => typeof(UsageOperation.UsageOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.CostManagement/forecast";

    internal class UsageOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
