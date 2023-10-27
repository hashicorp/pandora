using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Communication.v2023_04_01.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserEngagementTrackingConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
