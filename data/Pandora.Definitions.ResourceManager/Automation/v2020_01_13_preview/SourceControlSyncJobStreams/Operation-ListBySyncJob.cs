using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.SourceControlSyncJobStreams;

internal class ListBySyncJobOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SourceControlSyncJobId();

    public override Type NestedItemType() => typeof(SourceControlSyncJobStreamModel);

    public override Type? OptionsObject() => typeof(ListBySyncJobOperation.ListBySyncJobOptions);

    public override string? UriSuffix() => "/streams";

    internal class ListBySyncJobOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
