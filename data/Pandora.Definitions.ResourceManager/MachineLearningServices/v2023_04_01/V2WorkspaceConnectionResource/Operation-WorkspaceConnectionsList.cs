using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.V2WorkspaceConnectionResource;

internal class WorkspaceConnectionsListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new WorkspaceId();

    public override Type NestedItemType() => typeof(WorkspaceConnectionPropertiesV2BasicResourceModel);

    public override Type? OptionsObject() => typeof(WorkspaceConnectionsListOperation.WorkspaceConnectionsListOptions);

    public override string? UriSuffix() => "/connections";

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
