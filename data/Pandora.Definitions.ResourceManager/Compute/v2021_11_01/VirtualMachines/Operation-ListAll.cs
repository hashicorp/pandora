using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;

internal class ListAllOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(VirtualMachineModel);

    public override Type? OptionsObject() => typeof(ListAllOperation.ListAllOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Compute/virtualMachines";

    internal class ListAllOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("statusOnly")]
        [Optional]
        public string StatusOnly { get; set; }
    }
}
