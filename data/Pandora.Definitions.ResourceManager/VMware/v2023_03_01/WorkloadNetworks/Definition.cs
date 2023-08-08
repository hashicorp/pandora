using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.WorkloadNetworks;

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
        new GetOperation(),
        new GetDhcpOperation(),
        new GetDnsServiceOperation(),
        new GetDnsZoneOperation(),
        new GetGatewayOperation(),
        new GetPortMirroringOperation(),
        new GetPublicIPOperation(),
        new GetSegmentOperation(),
        new GetVMGroupOperation(),
        new GetVirtualMachineOperation(),
        new ListOperation(),
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
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DhcpTypeEnumConstant),
        typeof(DnsServiceLogLevelEnumConstant),
        typeof(DnsServiceStatusEnumConstant),
        typeof(PortMirroringDirectionEnumConstant),
        typeof(PortMirroringStatusEnumConstant),
        typeof(SegmentStatusEnumConstant),
        typeof(VMGroupStatusEnumConstant),
        typeof(VMTypeEnumConstant),
        typeof(WorkloadNetworkDhcpProvisioningStateConstant),
        typeof(WorkloadNetworkDnsServiceProvisioningStateConstant),
        typeof(WorkloadNetworkDnsZoneProvisioningStateConstant),
        typeof(WorkloadNetworkPortMirroringProvisioningStateConstant),
        typeof(WorkloadNetworkPublicIPProvisioningStateConstant),
        typeof(WorkloadNetworkSegmentProvisioningStateConstant),
        typeof(WorkloadNetworkVMGroupProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ResourceModel),
        typeof(WorkloadNetworkDhcpModel),
        typeof(WorkloadNetworkDhcpEntityModel),
        typeof(WorkloadNetworkDhcpRelayModel),
        typeof(WorkloadNetworkDhcpServerModel),
        typeof(WorkloadNetworkDnsServiceModel),
        typeof(WorkloadNetworkDnsServicePropertiesModel),
        typeof(WorkloadNetworkDnsZoneModel),
        typeof(WorkloadNetworkDnsZonePropertiesModel),
        typeof(WorkloadNetworkGatewayModel),
        typeof(WorkloadNetworkGatewayPropertiesModel),
        typeof(WorkloadNetworkPortMirroringModel),
        typeof(WorkloadNetworkPortMirroringPropertiesModel),
        typeof(WorkloadNetworkPublicIPModel),
        typeof(WorkloadNetworkPublicIPPropertiesModel),
        typeof(WorkloadNetworkSegmentModel),
        typeof(WorkloadNetworkSegmentPortVifModel),
        typeof(WorkloadNetworkSegmentPropertiesModel),
        typeof(WorkloadNetworkSegmentSubnetModel),
        typeof(WorkloadNetworkVMGroupModel),
        typeof(WorkloadNetworkVMGroupPropertiesModel),
        typeof(WorkloadNetworkVirtualMachineModel),
        typeof(WorkloadNetworkVirtualMachinePropertiesModel),
    };
}
