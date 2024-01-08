using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteConnections;

internal class ListOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ExpressRouteGatewayId();

    public override Type? ResponseObject() => typeof(ExpressRouteConnectionListModel);

    public override string? UriSuffix() => "/expressRouteConnections";


}
