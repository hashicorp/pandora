using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.Restorables;

internal class RestorableMongodbDatabasesListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new RestorableDatabaseAccountId();

    public override Type? ResponseObject() => typeof(RestorableMongodbDatabasesListResultModel);

    public override string? UriSuffix() => "/restorableMongodbDatabases";


}
