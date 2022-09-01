using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.DscCompilationJob;

internal class ListByAutomationAccountOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new AutomationAccountId();

    public override Type NestedItemType() => typeof(DscCompilationJobModel);

    public override Type? OptionsObject() => typeof(ListByAutomationAccountOperation.ListByAutomationAccountOptions);

    public override string? UriSuffix() => "/compilationjobs";

    internal class ListByAutomationAccountOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
