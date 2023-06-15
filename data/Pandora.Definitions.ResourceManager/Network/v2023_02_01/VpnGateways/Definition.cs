using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VpnGateways;

internal class Definition : ResourceDefinition
{
    public string Name => "VpnGateways";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ResetOperation(),
        new StartPacketCaptureOperation(),
        new StopPacketCaptureOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DhGroupConstant),
        typeof(IPsecEncryptionConstant),
        typeof(IPsecIntegrityConstant),
        typeof(IkeEncryptionConstant),
        typeof(IkeIntegrityConstant),
        typeof(PfsGroupConstant),
        typeof(ProvisioningStateConstant),
        typeof(VirtualNetworkGatewayConnectionProtocolConstant),
        typeof(VnetLocalRouteOverrideCriteriaConstant),
        typeof(VpnConnectionStatusConstant),
        typeof(VpnLinkConnectionModeConstant),
        typeof(VpnNatRuleModeConstant),
        typeof(VpnNatRuleTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BgpSettingsModel),
        typeof(GatewayCustomBgpIPAddressIPConfigurationModel),
        typeof(IPConfigurationBgpPeeringAddressModel),
        typeof(IPsecPolicyModel),
        typeof(PropagatedRouteTableModel),
        typeof(RoutingConfigurationModel),
        typeof(StaticRouteModel),
        typeof(StaticRoutesConfigModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
        typeof(TrafficSelectorPolicyModel),
        typeof(VnetRouteModel),
        typeof(VpnConnectionModel),
        typeof(VpnConnectionPropertiesModel),
        typeof(VpnGatewayModel),
        typeof(VpnGatewayIPConfigurationModel),
        typeof(VpnGatewayNatRuleModel),
        typeof(VpnGatewayNatRulePropertiesModel),
        typeof(VpnGatewayPacketCaptureStartParametersModel),
        typeof(VpnGatewayPacketCaptureStopParametersModel),
        typeof(VpnGatewayPropertiesModel),
        typeof(VpnNatRuleMappingModel),
        typeof(VpnSiteLinkConnectionModel),
        typeof(VpnSiteLinkConnectionPropertiesModel),
    };
}
