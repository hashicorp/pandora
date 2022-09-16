using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.WorkspaceManagedSqlServerSecurityAlertPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityAlertPolicyStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("New")]
    New,
}
