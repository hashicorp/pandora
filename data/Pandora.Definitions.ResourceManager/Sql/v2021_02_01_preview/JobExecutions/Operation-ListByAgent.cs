using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.JobExecutions;

internal class ListByAgentOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new JobAgentId();

    public override Type NestedItemType() => typeof(JobExecutionModel);

    public override Type? OptionsObject() => typeof(ListByAgentOperation.ListByAgentOptions);

    public override string? UriSuffix() => "/executions";

    internal class ListByAgentOptions
    {
        [QueryStringName("createTimeMax")]
        [Optional]
        public string CreateTimeMax { get; set; }

        [QueryStringName("createTimeMin")]
        [Optional]
        public string CreateTimeMin { get; set; }

        [QueryStringName("endTimeMax")]
        [Optional]
        public string EndTimeMax { get; set; }

        [QueryStringName("endTimeMin")]
        [Optional]
        public string EndTimeMin { get; set; }

        [QueryStringName("isActive")]
        [Optional]
        public bool IsActive { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
