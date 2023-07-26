using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.VirtualWANs;

internal class VirtualHubRouteTableV2sCreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(VirtualHubRouteTableV2Model);

    public override ResourceID? ResourceId() => new VirtualHubRouteTableId();

    public override Type? ResponseObject() => typeof(VirtualHubRouteTableV2Model);


}
