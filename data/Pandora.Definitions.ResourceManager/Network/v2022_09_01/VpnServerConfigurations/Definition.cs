using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.VpnServerConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "VpnServerConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
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
        typeof(VnetLocalRouteOverrideCriteriaConstant),
        typeof(VpnAuthenticationTypeConstant),
        typeof(VpnGatewayTunnelingProtocolConstant),
        typeof(VpnPolicyMemberAttributeTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AadAuthenticationParametersModel),
        typeof(AddressSpaceModel),
        typeof(IPsecPolicyModel),
        typeof(P2SConnectionConfigurationModel),
        typeof(P2SConnectionConfigurationPropertiesModel),
        typeof(P2SVpnGatewayModel),
        typeof(P2SVpnGatewayPropertiesModel),
        typeof(PropagatedRouteTableModel),
        typeof(RadiusServerModel),
        typeof(RoutingConfigurationModel),
        typeof(StaticRouteModel),
        typeof(StaticRoutesConfigModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
        typeof(VnetRouteModel),
        typeof(VpnClientConnectionHealthModel),
        typeof(VpnServerConfigRadiusClientRootCertificateModel),
        typeof(VpnServerConfigRadiusServerRootCertificateModel),
        typeof(VpnServerConfigVpnClientRevokedCertificateModel),
        typeof(VpnServerConfigVpnClientRootCertificateModel),
        typeof(VpnServerConfigurationModel),
        typeof(VpnServerConfigurationPolicyGroupModel),
        typeof(VpnServerConfigurationPolicyGroupMemberModel),
        typeof(VpnServerConfigurationPolicyGroupPropertiesModel),
        typeof(VpnServerConfigurationPropertiesModel),
    };
}
