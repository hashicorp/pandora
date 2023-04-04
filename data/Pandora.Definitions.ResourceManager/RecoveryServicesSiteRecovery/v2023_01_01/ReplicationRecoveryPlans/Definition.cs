using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_01_01.ReplicationRecoveryPlans;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationRecoveryPlans";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new FailoverCancelOperation(),
        new FailoverCommitOperation(),
        new GetOperation(),
        new ListOperation(),
        new PlannedFailoverOperation(),
        new ReprotectOperation(),
        new TestFailoverOperation(),
        new TestFailoverCleanupOperation(),
        new UnplannedFailoverOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(A2ARpRecoveryPointTypeConstant),
        typeof(AlternateLocationRecoveryOptionConstant),
        typeof(DataSyncStatusConstant),
        typeof(FailoverDeploymentModelConstant),
        typeof(HyperVReplicaAzureRpRecoveryPointTypeConstant),
        typeof(InMageRcmFailbackRecoveryPointTypeConstant),
        typeof(InMageV2RpRecoveryPointTypeConstant),
        typeof(MultiVMSyncPointOptionConstant),
        typeof(PossibleOperationsDirectionsConstant),
        typeof(RecoveryPlanActionLocationConstant),
        typeof(RecoveryPlanGroupTypeConstant),
        typeof(RecoveryPlanPointTypeConstant),
        typeof(ReplicationProtectedItemOperationConstant),
        typeof(RpInMageRecoveryPointTypeConstant),
        typeof(SourceSiteOperationsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateRecoveryPlanInputModel),
        typeof(CreateRecoveryPlanInputPropertiesModel),
        typeof(CurrentScenarioDetailsModel),
        typeof(RecoveryPlanModel),
        typeof(RecoveryPlanA2ADetailsModel),
        typeof(RecoveryPlanA2AFailoverInputModel),
        typeof(RecoveryPlanA2AInputModel),
        typeof(RecoveryPlanActionModel),
        typeof(RecoveryPlanActionDetailsModel),
        typeof(RecoveryPlanAutomationRunbookActionDetailsModel),
        typeof(RecoveryPlanGroupModel),
        typeof(RecoveryPlanHyperVReplicaAzureFailbackInputModel),
        typeof(RecoveryPlanHyperVReplicaAzureFailoverInputModel),
        typeof(RecoveryPlanInMageAzureV2FailoverInputModel),
        typeof(RecoveryPlanInMageFailoverInputModel),
        typeof(RecoveryPlanInMageRcmFailbackFailoverInputModel),
        typeof(RecoveryPlanInMageRcmFailoverInputModel),
        typeof(RecoveryPlanManualActionDetailsModel),
        typeof(RecoveryPlanPlannedFailoverInputModel),
        typeof(RecoveryPlanPlannedFailoverInputPropertiesModel),
        typeof(RecoveryPlanPropertiesModel),
        typeof(RecoveryPlanProtectedItemModel),
        typeof(RecoveryPlanProviderSpecificDetailsModel),
        typeof(RecoveryPlanProviderSpecificFailoverInputModel),
        typeof(RecoveryPlanProviderSpecificInputModel),
        typeof(RecoveryPlanScriptActionDetailsModel),
        typeof(RecoveryPlanTestFailoverCleanupInputModel),
        typeof(RecoveryPlanTestFailoverCleanupInputPropertiesModel),
        typeof(RecoveryPlanTestFailoverInputModel),
        typeof(RecoveryPlanTestFailoverInputPropertiesModel),
        typeof(RecoveryPlanUnplannedFailoverInputModel),
        typeof(RecoveryPlanUnplannedFailoverInputPropertiesModel),
        typeof(UpdateRecoveryPlanInputModel),
        typeof(UpdateRecoveryPlanInputPropertiesModel),
    };
}
