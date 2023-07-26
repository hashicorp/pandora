using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.NetworkInterfaces;

internal class GetVirtualMachineScaleSetNetworkInterfaceOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new VirtualMachineScaleSetNetworkInterfaceId();

    public override Type? ResponseObject() => typeof(NetworkInterfaceModel);

    public override Type? OptionsObject() => typeof(GetVirtualMachineScaleSetNetworkInterfaceOperation.GetVirtualMachineScaleSetNetworkInterfaceOptions);

    internal class GetVirtualMachineScaleSetNetworkInterfaceOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
