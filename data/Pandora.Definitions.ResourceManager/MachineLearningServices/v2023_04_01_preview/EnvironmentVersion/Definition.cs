using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.EnvironmentVersion;

internal class Definition : ResourceDefinition
{
    public string Name => "EnvironmentVersion";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new RegistryEnvironmentVersionsCreateOrUpdateOperation(),
        new RegistryEnvironmentVersionsDeleteOperation(),
        new RegistryEnvironmentVersionsGetOperation(),
        new RegistryEnvironmentVersionsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssetProvisioningStateConstant),
        typeof(AutoDeleteConditionConstant),
        typeof(AutoRebuildSettingConstant),
        typeof(EnvironmentTypeConstant),
        typeof(ListViewTypeConstant),
        typeof(OperatingSystemTypeConstant),
        typeof(ProtectionLevelConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoDeleteSettingModel),
        typeof(BuildContextModel),
        typeof(EnvironmentVersionModel),
        typeof(EnvironmentVersionResourceModel),
        typeof(InferenceContainerPropertiesModel),
        typeof(IntellectualPropertyModel),
        typeof(RouteModel),
    };
}
