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

internal class DatabaseAccountsListMetricsOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new DatabaseAccountId();

\t\tpublic override Type? ResponseObject() => typeof(MetricListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(DatabaseAccountsListMetricsOperation.DatabaseAccountsListMetricsOptions);

\t\tpublic override string? UriSuffix() => "/metrics";

    internal class DatabaseAccountsListMetricsOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
