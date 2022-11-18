using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2017_12_01.CheckNameAvailability;

internal class ExecuteOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(NameAvailabilityRequestModel);

\t\tpublic override ResourceID? ResourceId() => new SubscriptionId();

\t\tpublic override Type? ResponseObject() => typeof(NameAvailabilityModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.DBforPostgreSQL/checkNameAvailability";


}
