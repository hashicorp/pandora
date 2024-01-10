using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2023_04_01.PolicyDefinitionVersions;

internal class ListByManagementGroupOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new Providers2PolicyDefinitionId();

    public override Type NestedItemType() => typeof(PolicyDefinitionVersionModel);

    public override Type? OptionsObject() => typeof(ListByManagementGroupOperation.ListByManagementGroupOptions);

    public override string? UriSuffix() => "/versions";

    internal class ListByManagementGroupOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
