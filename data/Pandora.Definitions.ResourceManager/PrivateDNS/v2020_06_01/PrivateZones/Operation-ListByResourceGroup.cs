using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2020_06_01.PrivateZones;

internal class ListByResourceGroupOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ResourceGroupId();

\t\tpublic override Type NestedItemType() => typeof(PrivateZoneModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByResourceGroupOperation.ListByResourceGroupOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Network/privateDnsZones";

    internal class ListByResourceGroupOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
