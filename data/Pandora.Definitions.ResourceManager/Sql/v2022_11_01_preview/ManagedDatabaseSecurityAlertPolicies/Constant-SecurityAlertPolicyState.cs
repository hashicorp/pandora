using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedDatabaseSecurityAlertPolicies;

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
