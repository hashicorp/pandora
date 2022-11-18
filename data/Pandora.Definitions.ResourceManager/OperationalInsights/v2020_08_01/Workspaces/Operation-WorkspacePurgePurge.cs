using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.Workspaces;

internal class WorkspacePurgePurgeOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
        };

    public override Type? RequestObject() => typeof(WorkspacePurgeBodyModel);

\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type? ResponseObject() => typeof(WorkspacePurgeResponseModel);

\t\tpublic override string? UriSuffix() => "/purge";


}
