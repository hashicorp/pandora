using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.Applications;

internal class Definition : ResourceDefinition
{
    public string Name => "Applications";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateOrUpdateByIdOperation(),
        new DeleteOperation(),
        new DeleteByIdOperation(),
        new GetOperation(),
        new GetByIdOperation(),
        new ListAllowedUpgradePlansOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListTokensOperation(),
        new RefreshPermissionsOperation(),
        new UpdateOperation(),
        new UpdateAccessOperation(),
        new UpdateByIdOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApplicationArtifactNameConstant),
        typeof(ApplicationArtifactTypeConstant),
        typeof(ApplicationManagementModeConstant),
        typeof(JitApprovalModeConstant),
        typeof(JitApproverTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(ResourceIdentityTypeConstant),
        typeof(StatusConstant),
        typeof(SubstatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AllowedUpgradePlansResultModel),
        typeof(ApplicationModel),
        typeof(ApplicationArtifactModel),
        typeof(ApplicationAuthorizationModel),
        typeof(ApplicationBillingDetailsDefinitionModel),
        typeof(ApplicationClientDetailsModel),
        typeof(ApplicationJitAccessPolicyModel),
        typeof(ApplicationPackageContactModel),
        typeof(ApplicationPackageSupportUrlsModel),
        typeof(ApplicationPatchableModel),
        typeof(ApplicationPropertiesModel),
        typeof(IdentityModel),
        typeof(JitApproverDefinitionModel),
        typeof(JitRequestMetadataModel),
        typeof(ListTokenRequestModel),
        typeof(ManagedIdentityTokenModel),
        typeof(ManagedIdentityTokenResultModel),
        typeof(PlanModel),
        typeof(PlanPatchableModel),
        typeof(SkuModel),
        typeof(UpdateAccessDefinitionModel),
        typeof(UserAssignedResourceIdentityModel),
    };
}
