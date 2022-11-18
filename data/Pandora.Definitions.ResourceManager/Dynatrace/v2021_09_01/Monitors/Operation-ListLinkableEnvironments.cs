using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dynatrace.v2021_09_01.Monitors;

internal class ListLinkableEnvironmentsOperation : Operations.ListOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(LinkableEnvironmentRequestModel);

\t\tpublic override ResourceID? ResourceId() => new MonitorId();

\t\tpublic override Type NestedItemType() => typeof(LinkableEnvironmentResponseModel);

\t\tpublic override string? UriSuffix() => "/listLinkableEnvironments";

\t\tpublic override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
