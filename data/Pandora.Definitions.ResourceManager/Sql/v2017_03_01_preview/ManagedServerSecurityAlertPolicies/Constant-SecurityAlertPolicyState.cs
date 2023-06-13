using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.ManagedServerSecurityAlertPolicies;

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
