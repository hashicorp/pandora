using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.Environments;

internal class Definition : ResourceDefinition
{
    public string Name => "Environments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EnvironmentKindConstant),
        typeof(IngressStateConstant),
        typeof(KindConstant),
        typeof(PropertyTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(SkuNameConstant),
        typeof(StorageLimitExceededBehaviorConstant),
        typeof(WarmStoragePropertiesStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EnvironmentCreateOrUpdateParametersModel),
        typeof(EnvironmentListResponseModel),
        typeof(EnvironmentResourceModel),
        typeof(EnvironmentStateDetailsModel),
        typeof(EnvironmentStatusModel),
        typeof(EnvironmentUpdateParametersModel),
        typeof(Gen1EnvironmentCreateOrUpdateParametersModel),
        typeof(Gen1EnvironmentCreationPropertiesModel),
        typeof(Gen1EnvironmentMutablePropertiesModel),
        typeof(Gen1EnvironmentResourceModel),
        typeof(Gen1EnvironmentResourcePropertiesModel),
        typeof(Gen1EnvironmentUpdateParametersModel),
        typeof(Gen2EnvironmentCreateOrUpdateParametersModel),
        typeof(Gen2EnvironmentCreationPropertiesModel),
        typeof(Gen2EnvironmentMutablePropertiesModel),
        typeof(Gen2EnvironmentResourceModel),
        typeof(Gen2EnvironmentResourcePropertiesModel),
        typeof(Gen2EnvironmentUpdateParametersModel),
        typeof(Gen2StorageConfigurationInputModel),
        typeof(Gen2StorageConfigurationMutablePropertiesModel),
        typeof(Gen2StorageConfigurationOutputModel),
        typeof(IngressEnvironmentStatusModel),
        typeof(SkuModel),
        typeof(TimeSeriesIdPropertyModel),
        typeof(WarmStorageEnvironmentStatusModel),
        typeof(WarmStoragePropertiesUsageModel),
        typeof(WarmStoragePropertiesUsageStateDetailsModel),
        typeof(WarmStoreConfigurationPropertiesModel),
    };
}
