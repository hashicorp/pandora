using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2017_12_01.ServerSecurityAlertPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerSecurityAlertPolicyStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
