using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.SyncGroups;

internal class ListLogsOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SyncGroupId();

    public override Type NestedItemType() => typeof(SyncGroupLogPropertiesModel);

    public override Type? OptionsObject() => typeof(ListLogsOperation.ListLogsOptions);

    public override string? UriSuffix() => "/logs";

    internal class ListLogsOptions
    {
        [QueryStringName("continuationToken")]
        [Optional]
        public string ContinuationToken { get; set; }

        [QueryStringName("endTime")]
        public string EndTime { get; set; }

        [QueryStringName("startTime")]
        public string StartTime { get; set; }

        [QueryStringName("type")]
        public SyncGroupsTypeConstant Type { get; set; }
    }
}
