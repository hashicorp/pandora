using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationProtectedItemOperationConstant
{
    [Description("CancelFailover")]
    CancelFailover,

    [Description("ChangePit")]
    ChangePit,

    [Description("Commit")]
    Commit,

    [Description("CompleteMigration")]
    CompleteMigration,

    [Description("DisableProtection")]
    DisableProtection,

    [Description("Failback")]
    Failback,

    [Description("FinalizeFailback")]
    FinalizeFailback,

    [Description("PlannedFailover")]
    PlannedFailover,

    [Description("RepairReplication")]
    RepairReplication,

    [Description("ReverseReplicate")]
    ReverseReplicate,

    [Description("SwitchProtection")]
    SwitchProtection,

    [Description("TestFailover")]
    TestFailover,

    [Description("TestFailoverCleanup")]
    TestFailoverCleanup,

    [Description("UnplannedFailover")]
    UnplannedFailover,
}
