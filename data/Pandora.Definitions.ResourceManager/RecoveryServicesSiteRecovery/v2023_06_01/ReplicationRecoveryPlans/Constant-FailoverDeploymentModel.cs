using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FailoverDeploymentModelConstant
{
    [Description("Classic")]
    Classic,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("ResourceManager")]
    ResourceManager,
}
