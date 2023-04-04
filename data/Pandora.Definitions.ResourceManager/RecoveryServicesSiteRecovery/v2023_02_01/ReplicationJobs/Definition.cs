using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationJobs;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationJobs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new ExportOperation(),
        new GetOperation(),
        new ListOperation(),
        new RestartOperation(),
        new ResumeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExportJobOutputSerializationTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ASRTaskModel),
        typeof(AsrJobDetailsModel),
        typeof(AutomationRunbookTaskDetailsModel),
        typeof(ConsistencyCheckTaskDetailsModel),
        typeof(ExportJobDetailsModel),
        typeof(FabricReplicationGroupTaskDetailsModel),
        typeof(FailoverJobDetailsModel),
        typeof(FailoverReplicationProtectedItemDetailsModel),
        typeof(GroupTaskDetailsModel),
        typeof(InconsistentVMDetailsModel),
        typeof(InlineWorkflowTaskDetailsModel),
        typeof(JobModel),
        typeof(JobDetailsModel),
        typeof(JobEntityModel),
        typeof(JobErrorDetailsModel),
        typeof(JobPropertiesModel),
        typeof(JobQueryParameterModel),
        typeof(JobTaskDetailsModel),
        typeof(ManualActionTaskDetailsModel),
        typeof(ProviderErrorModel),
        typeof(RecoveryPlanGroupTaskDetailsModel),
        typeof(RecoveryPlanShutdownGroupTaskDetailsModel),
        typeof(ResumeJobParamsModel),
        typeof(ResumeJobParamsPropertiesModel),
        typeof(ScriptActionTaskDetailsModel),
        typeof(ServiceErrorModel),
        typeof(SwitchProtectionJobDetailsModel),
        typeof(TaskTypeDetailsModel),
        typeof(TestFailoverJobDetailsModel),
        typeof(VMNicUpdatesTaskDetailsModel),
        typeof(VirtualMachineTaskDetailsModel),
    };
}
