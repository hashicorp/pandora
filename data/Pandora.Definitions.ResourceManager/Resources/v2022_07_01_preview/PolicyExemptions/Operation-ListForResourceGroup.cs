using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_07_01_preview.PolicyExemptions;

internal class ListForResourceGroupOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type NestedItemType() => typeof(PolicyExemptionModel);

    public override Type? OptionsObject() => typeof(ListForResourceGroupOperation.ListForResourceGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Authorization/policyExemptions";

    internal class ListForResourceGroupOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
