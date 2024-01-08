using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.P2sVpnGateways;

internal class Definition : ResourceDefinition
{
    public string Name => "P2sVpnGateways";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DisconnectP2sVpnConnectionsOperation(),
        new GenerateVpnProfileOperation(),
        new GetP2sVpnConnectionHealthOperation(),
        new GetP2sVpnConnectionHealthDetailedOperation(),
        new ResetOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthenticationMethodConstant),
        typeof(ProvisioningStateConstant),
        typeof(VnetLocalRouteOverrideCriteriaConstant),
        typeof(VpnPolicyMemberAttributeTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddressSpaceModel),
        typeof(P2SConnectionConfigurationModel),
        typeof(P2SConnectionConfigurationPropertiesModel),
        typeof(P2SVpnConnectionHealthModel),
        typeof(P2SVpnConnectionHealthRequestModel),
        typeof(P2SVpnConnectionRequestModel),
        typeof(P2SVpnGatewayModel),
        typeof(P2SVpnGatewayPropertiesModel),
        typeof(P2SVpnProfileParametersModel),
        typeof(PropagatedRouteTableModel),
        typeof(RoutingConfigurationModel),
        typeof(StaticRouteModel),
        typeof(StaticRoutesConfigModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
        typeof(VnetRouteModel),
        typeof(VpnClientConnectionHealthModel),
        typeof(VpnProfileResponseModel),
        typeof(VpnServerConfigurationPolicyGroupModel),
        typeof(VpnServerConfigurationPolicyGroupMemberModel),
        typeof(VpnServerConfigurationPolicyGroupPropertiesModel),
    };
}
