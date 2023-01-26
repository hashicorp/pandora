using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkPeerings;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(VirtualNetworkPeeringModel);

    public override ResourceID? ResourceId() => new VirtualNetworkPeeringId();

    public override Type? ResponseObject() => typeof(VirtualNetworkPeeringModel);

    public override Type? OptionsObject() => typeof(CreateOrUpdateOperation.CreateOrUpdateOptions);

    internal class CreateOrUpdateOptions
    {
        [QueryStringName("syncRemoteAddressSpace")]
        [Optional]
        public SyncRemoteAddressSpaceConstant SyncRemoteAddressSpace { get; set; }
    }
}
