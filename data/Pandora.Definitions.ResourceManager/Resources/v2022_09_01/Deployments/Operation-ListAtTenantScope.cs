using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.Deployments;

internal class ListAtTenantScopeOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override Type NestedItemType() => typeof(DeploymentExtendedModel);

\t\tpublic override Type? OptionsObject() => typeof(ListAtTenantScopeOperation.ListAtTenantScopeOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Resources/deployments";

    internal class ListAtTenantScopeOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
