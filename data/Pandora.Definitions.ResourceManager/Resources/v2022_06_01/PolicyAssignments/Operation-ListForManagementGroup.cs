using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_06_01.PolicyAssignments;

internal class ListForManagementGroupOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ManagementGroupId();

    public override Type NestedItemType() => typeof(PolicyAssignmentModel);

    public override Type? OptionsObject() => typeof(ListForManagementGroupOperation.ListForManagementGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Authorization/policyAssignments";

    internal class ListForManagementGroupOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
