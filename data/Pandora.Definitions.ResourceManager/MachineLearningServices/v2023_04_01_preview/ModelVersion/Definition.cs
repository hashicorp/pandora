using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.ModelVersion;

internal class Definition : ResourceDefinition
{
    public string Name => "ModelVersion";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new PackageOperation(),
        new RegistryModelVersionsCreateOrGetStartPendingUploadOperation(),
        new RegistryModelVersionsCreateOrUpdateOperation(),
        new RegistryModelVersionsDeleteOperation(),
        new RegistryModelVersionsGetOperation(),
        new RegistryModelVersionsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssetProvisioningStateConstant),
        typeof(AutoDeleteConditionConstant),
        typeof(BaseEnvironmentSourceTypeConstant),
        typeof(InferencingServerTypeConstant),
        typeof(InputPathTypeConstant),
        typeof(ListViewTypeConstant),
        typeof(PackageBuildStateConstant),
        typeof(PackageInputDeliveryModeConstant),
        typeof(PackageInputTypeConstant),
        typeof(PendingUploadCredentialTypeConstant),
        typeof(PendingUploadTypeConstant),
        typeof(ProtectionLevelConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoDeleteSettingModel),
        typeof(AzureMLBatchInferencingServerModel),
        typeof(AzureMLOnlineInferencingServerModel),
        typeof(BaseEnvironmentIdModel),
        typeof(BaseEnvironmentSourceModel),
        typeof(BlobReferenceForConsumptionDtoModel),
        typeof(CodeConfigurationModel),
        typeof(CustomInferencingServerModel),
        typeof(FlavorDataModel),
        typeof(InferencingServerModel),
        typeof(IntellectualPropertyModel),
        typeof(ModelConfigurationModel),
        typeof(ModelPackageInputModel),
        typeof(ModelVersionModel),
        typeof(ModelVersionResourceModel),
        typeof(OnlineInferenceConfigurationModel),
        typeof(PackageInputPathBaseModel),
        typeof(PackageInputPathIdModel),
        typeof(PackageInputPathUrlModel),
        typeof(PackageInputPathVersionModel),
        typeof(PackageRequestModel),
        typeof(PackageResponseModel),
        typeof(PendingUploadCredentialDtoModel),
        typeof(PendingUploadRequestDtoModel),
        typeof(PendingUploadResponseDtoModel),
        typeof(RouteModel),
        typeof(SASCredentialDtoModel),
        typeof(TritonInferencingServerModel),
    };
}
