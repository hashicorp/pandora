using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.CapacityReservationGroups;

internal class ListByResourceGroupOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ResourceGroupId();

\t\tpublic override Type NestedItemType() => typeof(CapacityReservationGroupModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByResourceGroupOperation.ListByResourceGroupOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Compute/capacityReservationGroups";

    internal class ListByResourceGroupOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public ExpandTypesForGetCapacityReservationGroupsConstant Expand { get; set; }
    }
}
