using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Credits;

internal class GetOperation : Operations.GetOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

\t\tpublic override ResourceID? ResourceId() => new BillingProfileId();

\t\tpublic override Type? ResponseObject() => typeof(CreditSummaryModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Consumption/credits/balanceSummary";


}
