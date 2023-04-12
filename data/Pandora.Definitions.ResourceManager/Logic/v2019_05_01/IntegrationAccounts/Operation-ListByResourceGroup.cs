using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccounts;

internal class ListByResourceGroupOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type NestedItemType() => typeof(IntegrationAccountModel);

    public override Type? OptionsObject() => typeof(ListByResourceGroupOperation.ListByResourceGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Logic/integrationAccounts";

    internal class ListByResourceGroupOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
