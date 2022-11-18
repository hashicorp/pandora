using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2019_09_01.QueryPacks;

internal class QueryPacksCreateOrUpdateWithoutNameOperation : Operations.PutOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Created,
        };

    public override Type? RequestObject() => typeof(LogAnalyticsQueryPackModel);

\t\tpublic override ResourceID? ResourceId() => new ResourceGroupId();

\t\tpublic override Type? ResponseObject() => typeof(LogAnalyticsQueryPackModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.OperationalInsights/queryPacks";


}
