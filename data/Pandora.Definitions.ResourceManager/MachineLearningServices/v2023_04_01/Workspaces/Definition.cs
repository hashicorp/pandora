using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.Workspaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Workspaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DiagnoseOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new ListNotebookAccessTokenOperation(),
        new ResyncKeysOperation(),
        new UpdateOperation(),
        new WorkspaceFeaturesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DiagnoseResultLevelConstant),
        typeof(EncryptionStatusConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AmlUserFeatureModel),
        typeof(CosmosDbSettingsModel),
        typeof(DiagnoseRequestPropertiesModel),
        typeof(DiagnoseResponseResultModel),
        typeof(DiagnoseResponseResultValueModel),
        typeof(DiagnoseResultModel),
        typeof(DiagnoseWorkspaceParametersModel),
        typeof(EncryptionKeyVaultPropertiesModel),
        typeof(EncryptionPropertyModel),
        typeof(IdentityForCmkModel),
        typeof(ListNotebookKeysResultModel),
        typeof(ListWorkspaceKeysResultModel),
        typeof(NotebookAccessTokenResultModel),
        typeof(NotebookPreparationErrorModel),
        typeof(NotebookResourceInfoModel),
        typeof(PasswordModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(RegistryListCredentialsResultModel),
        typeof(ServiceManagedResourcesSettingsModel),
        typeof(SharedPrivateLinkResourceModel),
        typeof(SharedPrivateLinkResourcePropertyModel),
        typeof(SkuModel),
        typeof(WorkspaceModel),
        typeof(WorkspacePropertiesModel),
        typeof(WorkspacePropertiesUpdateParametersModel),
        typeof(WorkspaceUpdateParametersModel),
    };
}
