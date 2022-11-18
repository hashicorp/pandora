using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDB;

internal class GremlinResourcesUpdateGremlinDatabaseThroughputOperation : Operations.PutOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ThroughputSettingsUpdateParametersModel);

\t\tpublic override ResourceID? ResourceId() => new GremlinDatabaseId();

\t\tpublic override Type? ResponseObject() => typeof(ThroughputSettingsGetResultsModel);

\t\tpublic override string? UriSuffix() => "/throughputSettings/default";


}
