using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.ResourceGuards;

internal class Definition : ResourceDefinition
{
    public string Name => "ResourceGuards";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteOperation(),
        new GetOperation(),
        new GetBackupSecurityPINRequestsObjectsOperation(),
        new GetDefaultBackupSecurityPINRequestsObjectOperation(),
        new GetDefaultDeleteProtectedItemRequestsObjectOperation(),
        new GetDefaultDeleteResourceGuardProxyRequestsObjectOperation(),
        new GetDefaultDisableSoftDeleteRequestsObjectOperation(),
        new GetDefaultUpdateProtectedItemRequestsObjectOperation(),
        new GetDefaultUpdateProtectionPolicyRequestsObjectOperation(),
        new GetDeleteProtectedItemRequestsObjectsOperation(),
        new GetDeleteResourceGuardProxyRequestsObjectsOperation(),
        new GetDisableSoftDeleteRequestsObjectsOperation(),
        new GetResourcesInResourceGroupOperation(),
        new GetResourcesInSubscriptionOperation(),
        new GetUpdateProtectedItemRequestsObjectsOperation(),
        new GetUpdateProtectionPolicyRequestsObjectsOperation(),
        new PatchOperation(),
        new PutOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DppBaseResourceModel),
        typeof(PatchResourceGuardInputModel),
        typeof(ResourceGuardModel),
        typeof(ResourceGuardOperationModel),
        typeof(ResourceGuardResourceModel),
    };
}
