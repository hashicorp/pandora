using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.CapacityReservationGroups;

internal class ListBySubscriptionOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(CapacityReservationGroupModel);

    public override Type? OptionsObject() => typeof(ListBySubscriptionOperation.ListBySubscriptionOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Compute/capacityReservationGroups";

    internal class ListBySubscriptionOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public ExpandTypesForGetCapacityReservationGroupsConstant Expand { get; set; }
    }
}
