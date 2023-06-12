using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2020_03_01.PrivateEndpointConnections;

internal class ListByPolicyNameOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new PrivateLinkForAzureAdId();

    public override Type NestedItemType() => typeof(PrivateEndpointConnectionModel);

    public override string? UriSuffix() => "/privateEndpointConnections";


}
