using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.TagOperationLink;

internal class WorkspaceTagOperationLinkListByProductOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new WorkspaceTagId();

    public override Type NestedItemType() => typeof(TagOperationLinkContractModel);

    public override Type? OptionsObject() => typeof(WorkspaceTagOperationLinkListByProductOperation.WorkspaceTagOperationLinkListByProductOptions);

    public override string? UriSuffix() => "/operationLinks";

    internal class WorkspaceTagOperationLinkListByProductOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
