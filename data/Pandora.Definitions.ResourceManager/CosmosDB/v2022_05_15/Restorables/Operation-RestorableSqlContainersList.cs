using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.Restorables;

internal class RestorableSqlContainersListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new RestorableDatabaseAccountId();

\t\tpublic override Type? ResponseObject() => typeof(RestorableSqlContainersListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(RestorableSqlContainersListOperation.RestorableSqlContainersListOptions);

\t\tpublic override string? UriSuffix() => "/restorableSqlContainers";

    internal class RestorableSqlContainersListOptions
    {
        [QueryStringName("endTime")]
        [Optional]
        public string EndTime { get; set; }

        [QueryStringName("restorableSqlDatabaseRid")]
        [Optional]
        public string RestorableSqlDatabaseRid { get; set; }

        [QueryStringName("startTime")]
        [Optional]
        public string StartTime { get; set; }
    }
}
