using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.OutboundNetworkDependenciesEndpoints;

internal class ClustersListOutboundNetworkDependenciesEndpointsOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ClusterId();

    public override Type NestedItemType() => typeof(OutboundNetworkDependenciesEndpointModel);

    public override string? UriSuffix() => "/outboundNetworkDependenciesEndpoints";


}
