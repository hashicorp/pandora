using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HardwareSecurityModules.v2018_10_31_preview.DedicatedHsms;

internal class DedicatedHsmListByResourceGroupOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type NestedItemType() => typeof(DedicatedHsmModel);

    public override Type? OptionsObject() => typeof(DedicatedHsmListByResourceGroupOperation.DedicatedHsmListByResourceGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.HardwareSecurityModules/dedicatedHSMs";

    internal class DedicatedHsmListByResourceGroupOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
