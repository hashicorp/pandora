using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;

internal class Definition : ResourceDefinition
{
    public string Name => "SqlVirtualMachines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListBySqlVMGroupOperation(),
        new RedeployOperation(),
        new StartAssessmentOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssessmentDayOfWeekConstant),
        typeof(AutoBackupDaysOfWeekConstant),
        typeof(BackupScheduleTypeConstant),
        typeof(ConnectivityTypeConstant),
        typeof(DayOfWeekConstant),
        typeof(DiskConfigurationTypeConstant),
        typeof(FullBackupFrequencyTypeConstant),
        typeof(SqlImageSkuConstant),
        typeof(SqlManagementModeConstant),
        typeof(SqlServerLicenseTypeConstant),
        typeof(SqlWorkloadTypeConstant),
        typeof(StorageWorkloadTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdditionalFeaturesServerConfigurationsModel),
        typeof(AssessmentSettingsModel),
        typeof(AutoBackupSettingsModel),
        typeof(AutoPatchingSettingsModel),
        typeof(KeyVaultCredentialSettingsModel),
        typeof(SQLInstanceSettingsModel),
        typeof(SQLStorageSettingsModel),
        typeof(SQLTempDbSettingsModel),
        typeof(ScheduleModel),
        typeof(ServerConfigurationsManagementSettingsModel),
        typeof(SqlConnectivityUpdateSettingsModel),
        typeof(SqlStorageUpdateSettingsModel),
        typeof(SqlVirtualMachineModel),
        typeof(SqlVirtualMachinePropertiesModel),
        typeof(SqlVirtualMachineUpdateModel),
        typeof(SqlWorkloadTypeUpdateSettingsModel),
        typeof(StorageConfigurationSettingsModel),
        typeof(WsfcDomainCredentialsModel),
    };
}
