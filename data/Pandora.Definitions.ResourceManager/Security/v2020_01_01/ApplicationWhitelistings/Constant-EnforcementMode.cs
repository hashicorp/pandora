using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnforcementModeConstant
{
    [Description("Audit")]
    Audit,

    [Description("Enforce")]
    Enforce,

    [Description("None")]
    None,
}
