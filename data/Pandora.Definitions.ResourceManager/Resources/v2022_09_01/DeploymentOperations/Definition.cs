using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.DeploymentOperations;

internal class Definition : ResourceDefinition
{
    public string Name => "DeploymentOperations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetAtManagementGroupScopeOperation(),
        new GetAtScopeOperation(),
        new GetAtSubscriptionScopeOperation(),
        new GetAtTenantScopeOperation(),
        new ListOperation(),
        new ListAtManagementGroupScopeOperation(),
        new ListAtScopeOperation(),
        new ListAtSubscriptionScopeOperation(),
        new ListAtTenantScopeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningOperationConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DeploymentOperationModel),
        typeof(DeploymentOperationPropertiesModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorResponseModel),
        typeof(HTTPMessageModel),
        typeof(StatusMessageModel),
        typeof(TargetResourceModel),
    };
}
