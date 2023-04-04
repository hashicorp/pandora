using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.HostPool;

internal class Definition : ResourceDefinition
{
    public string Name => "HostPool";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RetrieveRegistrationTokenOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DayOfWeekConstant),
        typeof(HostPoolTypeConstant),
        typeof(HostpoolPublicNetworkAccessConstant),
        typeof(LoadBalancerTypeConstant),
        typeof(OperationConstant),
        typeof(PersonalDesktopAssignmentTypeConstant),
        typeof(PreferredAppGroupTypeConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(RegistrationTokenOperationConstant),
        typeof(SSOSecretTypeConstant),
        typeof(SessionHostComponentUpdateTypeConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AgentUpdatePatchPropertiesModel),
        typeof(AgentUpdatePropertiesModel),
        typeof(HostPoolModel),
        typeof(HostPoolPatchModel),
        typeof(HostPoolPatchPropertiesModel),
        typeof(HostPoolPropertiesModel),
        typeof(MaintenanceWindowPatchPropertiesModel),
        typeof(MaintenanceWindowPropertiesModel),
        typeof(MigrationRequestPropertiesModel),
        typeof(PlanModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(RegistrationInfoModel),
        typeof(RegistrationInfoPatchModel),
        typeof(SkuModel),
    };
}
