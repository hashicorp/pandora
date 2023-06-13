using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedDatabaseQueries;

internal class ListByQueryOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new QueryId();

    public override Type NestedItemType() => typeof(QueryStatisticsModel);

    public override Type? OptionsObject() => typeof(ListByQueryOperation.ListByQueryOptions);

    public override string? UriSuffix() => "/statistics";

    internal class ListByQueryOptions
    {
        [QueryStringName("endTime")]
        [Optional]
        public string EndTime { get; set; }

        [QueryStringName("interval")]
        [Optional]
        public QueryTimeGrainTypeConstant Interval { get; set; }

        [QueryStringName("startTime")]
        [Optional]
        public string StartTime { get; set; }
    }
}
