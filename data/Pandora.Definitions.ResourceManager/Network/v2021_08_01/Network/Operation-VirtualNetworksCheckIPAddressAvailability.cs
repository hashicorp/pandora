using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;

internal class VirtualNetworksCheckIPAddressAvailabilityOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new VirtualNetworkId();

    public override Type? ResponseObject() => typeof(IPAddressAvailabilityResultModel);

    public override Type? OptionsObject() => typeof(VirtualNetworksCheckIPAddressAvailabilityOperation.VirtualNetworksCheckIPAddressAvailabilityOptions);

    public override string? UriSuffix() => "/checkIPAddressAvailability";

    internal class VirtualNetworksCheckIPAddressAvailabilityOptions
    {
        [QueryStringName("ipAddress")]
        public string IPAddress { get; set; }
    }
}
