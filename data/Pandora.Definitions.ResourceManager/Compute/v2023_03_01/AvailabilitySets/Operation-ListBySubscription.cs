using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.AvailabilitySets;

internal class ListBySubscriptionOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(AvailabilitySetModel);

    public override Type? OptionsObject() => typeof(ListBySubscriptionOperation.ListBySubscriptionOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Compute/availabilitySets";

    internal class ListBySubscriptionOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
