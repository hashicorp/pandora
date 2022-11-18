using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.HybridRunbookWorkerGroup;

internal class ListByAutomationAccountOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new AutomationAccountId();

\t\tpublic override Type NestedItemType() => typeof(HybridRunbookWorkerGroupModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByAutomationAccountOperation.ListByAutomationAccountOptions);

\t\tpublic override string? UriSuffix() => "/hybridRunbookWorkerGroups";

    internal class ListByAutomationAccountOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
