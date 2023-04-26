using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27.Machines;

internal class Definition : ResourceDefinition
{
    public string Name => "Machines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssessPatchesOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new InstallPatchesOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AgentConfigurationModeConstant),
        typeof(AssessmentModeTypesConstant),
        typeof(InstanceViewTypesConstant),
        typeof(LastAttemptStatusEnumConstant),
        typeof(OsTypeConstant),
        typeof(PatchModeTypesConstant),
        typeof(PatchOperationStartedByConstant),
        typeof(PatchOperationStatusConstant),
        typeof(PatchServiceUsedConstant),
        typeof(StatusLevelTypesConstant),
        typeof(StatusTypesConstant),
        typeof(VMGuestPatchClassificationLinuxConstant),
        typeof(VMGuestPatchClassificationWindowsConstant),
        typeof(VMGuestPatchRebootSettingConstant),
        typeof(VMGuestPatchRebootStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AgentConfigurationModel),
        typeof(AgentUpgradeModel),
        typeof(AvailablePatchCountByClassificationModel),
        typeof(CloudMetadataModel),
        typeof(ConfigurationExtensionModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(LinuxParametersModel),
        typeof(LocationDataModel),
        typeof(MachineModel),
        typeof(MachineAssessPatchesResultModel),
        typeof(MachineExtensionModel),
        typeof(MachineExtensionInstanceViewModel),
        typeof(MachineExtensionInstanceViewStatusModel),
        typeof(MachineExtensionPropertiesModel),
        typeof(MachineInstallPatchesParametersModel),
        typeof(MachineInstallPatchesResultModel),
        typeof(MachinePropertiesModel),
        typeof(MachineUpdateModel),
        typeof(MachineUpdatePropertiesModel),
        typeof(OSProfileModel),
        typeof(OSProfileLinuxConfigurationModel),
        typeof(OSProfileWindowsConfigurationModel),
        typeof(PatchSettingsModel),
        typeof(ServiceStatusModel),
        typeof(ServiceStatusesModel),
        typeof(WindowsParametersModel),
    };
}
