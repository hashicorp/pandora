using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.VirtualNetworkGateways;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworkGateways";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DisconnectVirtualNetworkGatewayVpnConnectionsOperation(),
        new GenerateVpnProfileOperation(),
        new GeneratevpnclientpackageOperation(),
        new GetOperation(),
        new GetAdvertisedRoutesOperation(),
        new GetBgpPeerStatusOperation(),
        new GetLearnedRoutesOperation(),
        new GetVpnProfilePackageUrlOperation(),
        new GetVpnclientConnectionHealthOperation(),
        new GetVpnclientIPsecParametersOperation(),
        new ListOperation(),
        new ListConnectionsOperation(),
        new ResetOperation(),
        new ResetVpnClientSharedKeyOperation(),
        new SetVpnclientIPsecParametersOperation(),
        new StartPacketCaptureOperation(),
        new StopPacketCaptureOperation(),
        new SupportedVpnDevicesOperation(),
        new UpdateTagsOperation(),
        new VirtualNetworkGatewayNatRulesCreateOrUpdateOperation(),
        new VirtualNetworkGatewayNatRulesDeleteOperation(),
        new VirtualNetworkGatewayNatRulesGetOperation(),
        new VirtualNetworkGatewayNatRulesListByVirtualNetworkGatewayOperation(),
        new VpnDeviceConfigurationScriptOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdminStateConstant),
        typeof(AuthenticationMethodConstant),
        typeof(BgpPeerStateConstant),
        typeof(DhGroupConstant),
        typeof(IPAllocationMethodConstant),
        typeof(IPsecEncryptionConstant),
        typeof(IPsecIntegrityConstant),
        typeof(IkeEncryptionConstant),
        typeof(IkeIntegrityConstant),
        typeof(PfsGroupConstant),
        typeof(ProcessorArchitectureConstant),
        typeof(ProvisioningStateConstant),
        typeof(VirtualNetworkGatewayConnectionModeConstant),
        typeof(VirtualNetworkGatewayConnectionProtocolConstant),
        typeof(VirtualNetworkGatewayConnectionStatusConstant),
        typeof(VirtualNetworkGatewayConnectionTypeConstant),
        typeof(VirtualNetworkGatewaySkuNameConstant),
        typeof(VirtualNetworkGatewaySkuTierConstant),
        typeof(VirtualNetworkGatewayTypeConstant),
        typeof(VpnAuthenticationTypeConstant),
        typeof(VpnClientProtocolConstant),
        typeof(VpnGatewayGenerationConstant),
        typeof(VpnNatRuleModeConstant),
        typeof(VpnNatRuleTypeConstant),
        typeof(VpnPolicyMemberAttributeTypeConstant),
        typeof(VpnTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddressSpaceModel),
        typeof(BgpPeerStatusModel),
        typeof(BgpPeerStatusListResultModel),
        typeof(BgpSettingsModel),
        typeof(GatewayCustomBgpIPAddressIPConfigurationModel),
        typeof(GatewayRouteModel),
        typeof(GatewayRouteListResultModel),
        typeof(IPConfigurationBgpPeeringAddressModel),
        typeof(IPsecPolicyModel),
        typeof(P2SVpnConnectionRequestModel),
        typeof(RadiusServerModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
        typeof(TrafficSelectorPolicyModel),
        typeof(TunnelConnectionHealthModel),
        typeof(VirtualNetworkConnectionGatewayReferenceModel),
        typeof(VirtualNetworkGatewayModel),
        typeof(VirtualNetworkGatewayConnectionListEntityModel),
        typeof(VirtualNetworkGatewayConnectionListEntityPropertiesFormatModel),
        typeof(VirtualNetworkGatewayIPConfigurationModel),
        typeof(VirtualNetworkGatewayIPConfigurationPropertiesFormatModel),
        typeof(VirtualNetworkGatewayNatRuleModel),
        typeof(VirtualNetworkGatewayNatRulePropertiesModel),
        typeof(VirtualNetworkGatewayPolicyGroupModel),
        typeof(VirtualNetworkGatewayPolicyGroupMemberModel),
        typeof(VirtualNetworkGatewayPolicyGroupPropertiesModel),
        typeof(VirtualNetworkGatewayPropertiesFormatModel),
        typeof(VirtualNetworkGatewaySkuModel),
        typeof(VngClientConnectionConfigurationModel),
        typeof(VngClientConnectionConfigurationPropertiesModel),
        typeof(VpnClientConfigurationModel),
        typeof(VpnClientConnectionHealthDetailModel),
        typeof(VpnClientConnectionHealthDetailListResultModel),
        typeof(VpnClientIPsecParametersModel),
        typeof(VpnClientParametersModel),
        typeof(VpnClientRevokedCertificateModel),
        typeof(VpnClientRevokedCertificatePropertiesFormatModel),
        typeof(VpnClientRootCertificateModel),
        typeof(VpnClientRootCertificatePropertiesFormatModel),
        typeof(VpnDeviceScriptParametersModel),
        typeof(VpnNatRuleMappingModel),
        typeof(VpnPacketCaptureStartParametersModel),
        typeof(VpnPacketCaptureStopParametersModel),
    };
}
