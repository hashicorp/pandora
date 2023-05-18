using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.NetworkManagerConnections;

internal class ManagementGroupNetworkManagerConnectionsListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ManagementGroupId();

    public override Type NestedItemType() => typeof(NetworkManagerConnectionModel);

    public override Type? OptionsObject() => typeof(ManagementGroupNetworkManagerConnectionsListOperation.ManagementGroupNetworkManagerConnectionsListOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Network/networkManagerConnections";

    internal class ManagementGroupNetworkManagerConnectionsListOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
