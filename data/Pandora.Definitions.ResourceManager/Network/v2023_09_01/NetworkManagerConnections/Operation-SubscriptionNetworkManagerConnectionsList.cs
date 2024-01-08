using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.NetworkManagerConnections;

internal class SubscriptionNetworkManagerConnectionsListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(NetworkManagerConnectionModel);

    public override Type? OptionsObject() => typeof(SubscriptionNetworkManagerConnectionsListOperation.SubscriptionNetworkManagerConnectionsListOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Network/networkManagerConnections";

    internal class SubscriptionNetworkManagerConnectionsListOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
