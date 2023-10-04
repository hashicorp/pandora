using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15.CosmosDB;

internal class GremlinResourcesUpdateGremlinDatabaseThroughputOperation : Pandora.Definitions.Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ThroughputSettingsUpdateParametersModel);

    public override ResourceID? ResourceId() => new GremlinDatabaseId();

    public override Type? ResponseObject() => typeof(ThroughputSettingsGetResultsModel);

    public override string? UriSuffix() => "/throughputSettings/default";


}
