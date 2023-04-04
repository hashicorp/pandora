using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.RecoveryPoints;

internal class Definition : ResourceDefinition
{
    public string Name => "RecoveryPoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RecoveryPointTierStatusConstant),
        typeof(RecoveryPointTierTypeConstant),
        typeof(RestorePointTypeConstant),
        typeof(SQLDataDirectoryTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureFileShareRecoveryPointModel),
        typeof(AzureWorkloadPointInTimeRecoveryPointModel),
        typeof(AzureWorkloadRecoveryPointModel),
        typeof(AzureWorkloadSAPHanaRecoveryPointModel),
        typeof(AzureWorkloadSQLRecoveryPointModel),
        typeof(AzureWorkloadSQLRecoveryPointExtendedInfoModel),
        typeof(BEKDetailsModel),
        typeof(DiskInformationModel),
        typeof(GenericRecoveryPointModel),
        typeof(IaasVMRecoveryPointModel),
        typeof(KEKDetailsModel),
        typeof(KeyAndSecretDetailsModel),
        typeof(PointInTimeRangeModel),
        typeof(RecoveryPointModel),
        typeof(RecoveryPointDiskConfigurationModel),
        typeof(RecoveryPointMoveReadinessInfoModel),
        typeof(RecoveryPointResourceModel),
        typeof(RecoveryPointTierInformationV2Model),
        typeof(SQLDataDirectoryModel),
    };
}
