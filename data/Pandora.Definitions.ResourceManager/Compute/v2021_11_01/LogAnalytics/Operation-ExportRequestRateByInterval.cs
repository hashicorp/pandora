using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.LogAnalytics;

internal class ExportRequestRateByIntervalOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(RequestRateByIntervalInputModel);

\t\tpublic override ResourceID? ResourceId() => new LocationId();

\t\tpublic override Type? ResponseObject() => typeof(LogAnalyticsOperationResultModel);

\t\tpublic override string? UriSuffix() => "/logAnalytics/apiAccess/getRequestRateByInterval";


}
