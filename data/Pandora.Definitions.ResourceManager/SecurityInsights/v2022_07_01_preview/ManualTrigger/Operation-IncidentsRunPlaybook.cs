using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.ManualTrigger;

internal class IncidentsRunPlaybookOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };

    public override Type? RequestObject() => typeof(ManualTriggerRequestBodyModel);

\t\tpublic override ResourceID? ResourceId() => new IncidentId();

\t\tpublic override Type? ResponseObject() => typeof(object);

\t\tpublic override string? UriSuffix() => "/runPlaybook";


}
