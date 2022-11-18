using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.V2WorkspaceConnectionResource;

internal class WorkspaceConnectionsListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type NestedItemType() => typeof(WorkspaceConnectionPropertiesV2BasicResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(WorkspaceConnectionsListOperation.WorkspaceConnectionsListOptions);

\t\tpublic override string? UriSuffix() => "/connections";

    internal class WorkspaceConnectionsListOptions
    {
        [QueryStringName("category")]
        [Optional]
        public string Category { get; set; }

        [QueryStringName("target")]
        [Optional]
        public string Target { get; set; }
    }
}
