using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationMigrationItems;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationMigrationItems";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByReplicationProtectionContainersOperation(),
        new MigrateOperation(),
        new PauseReplicationOperation(),
        new ResumeReplicationOperation(),
        new ResyncOperation(),
        new TestMigrateOperation(),
        new TestMigrateCleanupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DiskAccountTypeConstant),
        typeof(EthernetAddressTypeConstant),
        typeof(HealthErrorCustomerResolvabilityConstant),
        typeof(LicenseTypeConstant),
        typeof(MigrationItemOperationConstant),
        typeof(MigrationStateConstant),
        typeof(ProtectionHealthConstant),
        typeof(ResyncStateConstant),
        typeof(SecurityTypeConstant),
        typeof(SqlServerLicenseTypeConstant),
        typeof(TestMigrationStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CriticalJobHistoryDetailsModel),
        typeof(CurrentJobDetailsModel),
        typeof(EnableMigrationInputModel),
        typeof(EnableMigrationInputPropertiesModel),
        typeof(EnableMigrationProviderSpecificInputModel),
        typeof(HealthErrorModel),
        typeof(InnerHealthErrorModel),
        typeof(MigrateInputModel),
        typeof(MigrateInputPropertiesModel),
        typeof(MigrateProviderSpecificInputModel),
        typeof(MigrationItemModel),
        typeof(MigrationItemPropertiesModel),
        typeof(MigrationProviderSpecificSettingsModel),
        typeof(PauseReplicationInputModel),
        typeof(PauseReplicationInputPropertiesModel),
        typeof(ResumeReplicationInputModel),
        typeof(ResumeReplicationInputPropertiesModel),
        typeof(ResumeReplicationProviderSpecificInputModel),
        typeof(ResyncInputModel),
        typeof(ResyncInputPropertiesModel),
        typeof(ResyncProviderSpecificInputModel),
        typeof(TestMigrateCleanupInputModel),
        typeof(TestMigrateCleanupInputPropertiesModel),
        typeof(TestMigrateInputModel),
        typeof(TestMigrateInputPropertiesModel),
        typeof(TestMigrateProviderSpecificInputModel),
        typeof(UpdateMigrationItemInputModel),
        typeof(UpdateMigrationItemInputPropertiesModel),
        typeof(UpdateMigrationItemProviderSpecificInputModel),
        typeof(VMwareCbtDiskInputModel),
        typeof(VMwareCbtEnableMigrationInputModel),
        typeof(VMwareCbtMigrateInputModel),
        typeof(VMwareCbtMigrationDetailsModel),
        typeof(VMwareCbtNicDetailsModel),
        typeof(VMwareCbtNicInputModel),
        typeof(VMwareCbtProtectedDiskDetailsModel),
        typeof(VMwareCbtResumeReplicationInputModel),
        typeof(VMwareCbtResyncInputModel),
        typeof(VMwareCbtSecurityProfilePropertiesModel),
        typeof(VMwareCbtTestMigrateInputModel),
        typeof(VMwareCbtUpdateDiskInputModel),
        typeof(VMwareCbtUpdateMigrationItemInputModel),
    };
}
