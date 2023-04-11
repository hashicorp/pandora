using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_03_15.CosmosDB;

internal class GremlinResourcesListGremlinGraphsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new GremlinDatabaseId();

    public override Type? ResponseObject() => typeof(GremlinGraphListResultModel);

    public override string? UriSuffix() => "/graphs";


}
