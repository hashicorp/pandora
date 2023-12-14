using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.RecoveryPointsRecommendedForMove;

internal class Definition : ResourceDefinition
{
    public string Name => "RecoveryPointsRecommendedForMove";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
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
        typeof(AzureWorkloadSAPHanaPointInTimeRecoveryPointModel),
        typeof(AzureWorkloadSAPHanaRecoveryPointModel),
        typeof(AzureWorkloadSQLPointInTimeRecoveryPointModel),
        typeof(AzureWorkloadSQLRecoveryPointModel),
        typeof(AzureWorkloadSQLRecoveryPointExtendedInfoModel),
        typeof(BEKDetailsModel),
        typeof(DiskInformationModel),
        typeof(ExtendedLocationModel),
        typeof(GenericRecoveryPointModel),
        typeof(IaasVMRecoveryPointModel),
        typeof(KEKDetailsModel),
        typeof(KeyAndSecretDetailsModel),
        typeof(ListRecoveryPointsRecommendedForMoveRequestModel),
        typeof(PointInTimeRangeModel),
        typeof(RecoveryPointModel),
        typeof(RecoveryPointDiskConfigurationModel),
        typeof(RecoveryPointMoveReadinessInfoModel),
        typeof(RecoveryPointPropertiesModel),
        typeof(RecoveryPointResourceModel),
        typeof(RecoveryPointTierInformationV2Model),
        typeof(SQLDataDirectoryModel),
    };
}
