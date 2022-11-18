using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Workspaces;

internal class ListBySubscriptionOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new SubscriptionId();

\t\tpublic override Type NestedItemType() => typeof(WorkspaceModel);

\t\tpublic override Type? OptionsObject() => typeof(ListBySubscriptionOperation.ListBySubscriptionOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.MachineLearningServices/workspaces";

    internal class ListBySubscriptionOptions
    {
        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }
    }
}
