using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstances;

internal class ListByManagedInstanceOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ManagedInstanceId();

    public override Type NestedItemType() => typeof(TopQueriesModel);

    public override Type? OptionsObject() => typeof(ListByManagedInstanceOperation.ListByManagedInstanceOptions);

    public override string? UriSuffix() => "/topqueries";

    internal class ListByManagedInstanceOptions
    {
        [QueryStringName("aggregationFunction")]
        [Optional]
        public AggregationFunctionTypeConstant AggregationFunction { get; set; }

        [QueryStringName("databases")]
        [Optional]
        public string Databases { get; set; }

        [QueryStringName("endTime")]
        [Optional]
        public string EndTime { get; set; }

        [QueryStringName("interval")]
        [Optional]
        public QueryTimeGrainTypeConstant Interval { get; set; }

        [QueryStringName("numberOfQueries")]
        [Optional]
        public int NumberOfQueries { get; set; }

        [QueryStringName("observationMetric")]
        [Optional]
        public MetricTypeConstant ObservationMetric { get; set; }

        [QueryStringName("startTime")]
        [Optional]
        public string StartTime { get; set; }
    }
}
