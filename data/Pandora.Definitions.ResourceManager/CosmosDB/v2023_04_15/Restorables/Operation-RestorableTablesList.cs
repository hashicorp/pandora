using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_04_15.Restorables;

internal class RestorableTablesListOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new RestorableDatabaseAccountId();

    public override Type? ResponseObject() => typeof(RestorableTablesListResultModel);

    public override Type? OptionsObject() => typeof(RestorableTablesListOperation.RestorableTablesListOptions);

    public override string? UriSuffix() => "/restorableTables";

    internal class RestorableTablesListOptions
    {
        [QueryStringName("endTime")]
        [Optional]
        public string EndTime { get; set; }

        [QueryStringName("startTime")]
        [Optional]
        public string StartTime { get; set; }
    }
}
