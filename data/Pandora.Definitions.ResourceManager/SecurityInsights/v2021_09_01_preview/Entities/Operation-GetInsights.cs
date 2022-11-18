using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Entities;

internal class GetInsightsOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(EntityGetInsightsParametersModel);

\t\tpublic override ResourceID? ResourceId() => new EntityId();

\t\tpublic override Type? ResponseObject() => typeof(EntityGetInsightsResponseModel);

\t\tpublic override string? UriSuffix() => "/getInsights";


}
