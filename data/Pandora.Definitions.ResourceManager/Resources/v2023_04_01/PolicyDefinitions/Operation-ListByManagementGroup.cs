using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2023_04_01.PolicyDefinitions;

internal class ListByManagementGroupOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ManagementGroupId();

    public override Type NestedItemType() => typeof(PolicyDefinitionModel);

    public override Type? OptionsObject() => typeof(ListByManagementGroupOperation.ListByManagementGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Authorization/policyDefinitions";

    internal class ListByManagementGroupOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
