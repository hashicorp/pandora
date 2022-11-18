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

internal class DatabaseAccountRegionListMetricsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new RegionId();

    public override Type? ResponseObject() => typeof(MetricListResultModel);

    public override Type? OptionsObject() => typeof(DatabaseAccountRegionListMetricsOperation.DatabaseAccountRegionListMetricsOptions);

    public override string? UriSuffix() => "/metrics";

    internal class DatabaseAccountRegionListMetricsOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
