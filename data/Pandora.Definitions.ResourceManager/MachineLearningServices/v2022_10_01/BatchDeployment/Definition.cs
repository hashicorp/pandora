using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.BatchDeployment;

internal class Definition : ResourceDefinition
{
    public string Name => "BatchDeployment";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BatchLoggingLevelConstant),
        typeof(BatchOutputActionConstant),
        typeof(DeploymentProvisioningStateConstant),
        typeof(ReferenceTypeConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssetReferenceBaseModel),
        typeof(BatchDeploymentModel),
        typeof(BatchDeploymentTrackedResourceModel),
        typeof(BatchRetrySettingsModel),
        typeof(CodeConfigurationModel),
        typeof(DataPathAssetReferenceModel),
        typeof(IdAssetReferenceModel),
        typeof(OutputPathAssetReferenceModel),
        typeof(PartialBatchDeploymentModel),
        typeof(PartialBatchDeploymentPartialMinimalTrackedResourceWithPropertiesModel),
        typeof(ResourceConfigurationModel),
        typeof(SkuModel),
    };
}
