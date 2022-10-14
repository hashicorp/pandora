using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.WorkloadNetworks;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkloadNetworks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDhcpOperation(),
        new CreateDnsServiceOperation(),
        new CreateDnsZoneOperation(),
        new CreatePortMirroringOperation(),
        new CreatePublicIPOperation(),
        new CreateSegmentsOperation(),
        new CreateVMGroupOperation(),
        new DeleteDhcpOperation(),
        new DeleteDnsServiceOperation(),
        new DeleteDnsZoneOperation(),
        new DeletePortMirroringOperation(),
        new DeletePublicIPOperation(),
        new DeleteSegmentOperation(),
        new DeleteVMGroupOperation(),
        new GetDhcpOperation(),
        new GetDnsServiceOperation(),
        new GetDnsZoneOperation(),
        new GetGatewayOperation(),
        new GetPortMirroringOperation(),
        new GetPublicIPOperation(),
        new GetSegmentOperation(),
        new GetVMGroupOperation(),
        new GetVirtualMachineOperation(),
        new ListDhcpOperation(),
        new ListDnsServicesOperation(),
        new ListDnsZonesOperation(),
        new ListGatewaysOperation(),
        new ListPortMirroringOperation(),
        new ListPublicIPsOperation(),
        new ListSegmentsOperation(),
        new ListVMGroupsOperation(),
        new ListVirtualMachinesOperation(),
        new UpdateDhcpOperation(),
        new UpdateDnsServiceOperation(),
        new UpdateDnsZoneOperation(),
        new UpdatePortMirroringOperation(),
        new UpdateSegmentsOperation(),
        new UpdateVMGroupOperation(),
    };
}
