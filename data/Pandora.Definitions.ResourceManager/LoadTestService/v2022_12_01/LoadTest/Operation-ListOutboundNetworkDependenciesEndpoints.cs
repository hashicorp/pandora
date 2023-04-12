using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LoadTestService.v2022_12_01.LoadTest;

internal class ListOutboundNetworkDependenciesEndpointsOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new LoadTestId();

    public override Type NestedItemType() => typeof(OutboundEnvironmentEndpointModel);

    public override string? UriSuffix() => "/outboundNetworkDependenciesEndpoints";


}
