using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.CosmosDB;

internal class CassandraResourcesListCassandraTablesOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new CassandraKeyspaceId();

    public override Type? ResponseObject() => typeof(CassandraTableListResultModel);

    public override string? UriSuffix() => "/tables";


}
