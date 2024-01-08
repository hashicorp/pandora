using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VirtualNetworkGatewayConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworkGatewayConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetIkeSasOperation(),
        new GetSharedKeyOperation(),
        new ListOperation(),
        new ResetConnectionOperation(),
        new ResetSharedKeyOperation(),
        new SetSharedKeyOperation(),
        new StartPacketCaptureOperation(),
        new StopPacketCaptureOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdminStateConstant),
        typeof(DhGroupConstant),
        typeof(IPAllocationMethodConstant),
        typeof(IPsecEncryptionConstant),
        typeof(IPsecIntegrityConstant),
        typeof(IkeEncryptionConstant),
        typeof(IkeIntegrityConstant),
        typeof(PfsGroupConstant),
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
        typeof(BgpSettingsModel),
        typeof(ConnectionResetSharedKeyModel),
        typeof(ConnectionSharedKeyModel),
        typeof(GatewayCustomBgpIPAddressIPConfigurationModel),
        typeof(IPConfigurationBgpPeeringAddressModel),
        typeof(IPsecPolicyModel),
        typeof(LocalNetworkGatewayModel),
        typeof(LocalNetworkGatewayPropertiesFormatModel),
        typeof(RadiusServerModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
        typeof(TrafficSelectorPolicyModel),
        typeof(TunnelConnectionHealthModel),
        typeof(VirtualNetworkGatewayModel),
        typeof(VirtualNetworkGatewayAutoScaleBoundsModel),
        typeof(VirtualNetworkGatewayAutoScaleConfigurationModel),
        typeof(VirtualNetworkGatewayConnectionModel),
        typeof(VirtualNetworkGatewayConnectionPropertiesFormatModel),
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
        typeof(VpnClientRevokedCertificateModel),
        typeof(VpnClientRevokedCertificatePropertiesFormatModel),
        typeof(VpnClientRootCertificateModel),
        typeof(VpnClientRootCertificatePropertiesFormatModel),
        typeof(VpnNatRuleMappingModel),
        typeof(VpnPacketCaptureStartParametersModel),
        typeof(VpnPacketCaptureStopParametersModel),
    };
}
