using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.CosmosDB;

internal class CollectionRegionListMetricsOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new DatabaseCollectionId();

    public override Type? ResponseObject() => typeof(MetricListResultModel);

    public override Type? OptionsObject() => typeof(CollectionRegionListMetricsOperation.CollectionRegionListMetricsOptions);

    public override string? UriSuffix() => "/metrics";

    internal class CollectionRegionListMetricsOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
