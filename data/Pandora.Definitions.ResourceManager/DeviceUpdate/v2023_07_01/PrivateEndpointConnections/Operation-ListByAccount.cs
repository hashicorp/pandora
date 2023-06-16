using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2023_07_01.PrivateEndpointConnections;

internal class ListByAccountOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new AccountId();

    public override Type? ResponseObject() => typeof(PrivateEndpointConnectionListResultModel);

    public override string? UriSuffix() => "/privateEndpointConnections";


}
