using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_03_10.Machines;

internal class Definition : ResourceDefinition
{
    public string Name => "Machines";
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
        typeof(AssessmentModeTypesConstant),
        typeof(InstanceViewTypesConstant),
        typeof(PatchModeTypesConstant),
        typeof(StatusLevelTypesConstant),
        typeof(StatusTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AgentConfigurationModel),
        typeof(CloudMetadataModel),
        typeof(ConfigurationExtensionModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(LocationDataModel),
        typeof(MachineModel),
        typeof(MachineExtensionInstanceViewModel),
        typeof(MachineExtensionInstanceViewStatusModel),
        typeof(MachinePropertiesModel),
        typeof(MachineUpdateModel),
        typeof(MachineUpdatePropertiesModel),
        typeof(OSProfileModel),
        typeof(OSProfileLinuxConfigurationModel),
        typeof(OSProfileWindowsConfigurationModel),
        typeof(PatchSettingsModel),
        typeof(ServiceStatusModel),
        typeof(ServiceStatusesModel),
    };
}
