using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.SourceControlSyncJob;

internal class ListByAutomationAccountOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SourceControlId();

    public override Type NestedItemType() => typeof(SourceControlSyncJobModel);

    public override Type? OptionsObject() => typeof(ListByAutomationAccountOperation.ListByAutomationAccountOptions);

    public override string? UriSuffix() => "/sourceControlSyncJobs";

    internal class ListByAutomationAccountOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
