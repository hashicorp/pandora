using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.GET;

internal class Definition : ResourceDefinition
{
    public string Name => "GET";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DpsCertificateGetOperation(),
        new DpsCertificateListOperation(),
        new IotDpsResourceGetOperation(),
        new IotDpsResourceGetPrivateEndpointConnectionOperation(),
        new IotDpsResourceGetPrivateLinkResourcesOperation(),
        new IotDpsResourceListByResourceGroupOperation(),
        new IotDpsResourceListBySubscriptionOperation(),
        new IotDpsResourceListPrivateEndpointConnectionsOperation(),
        new IotDpsResourceListPrivateLinkResourcesOperation(),
        new IotDpsResourcelistValidSkusOperation(),
    };
}
